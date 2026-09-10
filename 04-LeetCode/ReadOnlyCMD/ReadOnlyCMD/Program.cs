using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using SQLitePCL;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace BrowserPasswordViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Batteries.Init();

            Console.WriteLine("🔍 Browser Password Viewer - ULTIMATE DEBUG VERSION");
            Console.WriteLine("====================================================");

            try
            {
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string chromeUserData = Path.Combine(localAppData, @"Google\Chrome\User Data");
                string localStatePath = Path.Combine(chromeUserData, "Local State");
                string loginDataPath = Path.Combine(chromeUserData, @"Default\Login Data");

                if (!File.Exists(loginDataPath) || !File.Exists(localStatePath))
                {
                    Console.WriteLine("❌ Required files not found!");
                    return;
                }

                // Get decryption key
                Console.WriteLine("\n🔑 Step 1: Retrieving decryption key...");
                byte[] decryptionKey = GetDecryptionKey(localStatePath);

                if (decryptionKey == null)
                {
                    Console.WriteLine("❌ Failed to retrieve decryption key!");
                    return;
                }

                Console.WriteLine($"✅ Decryption key: {BitConverter.ToString(decryptionKey).Replace("-", " ")}");

                // Copy database
                string tempFile = Path.Combine(Path.GetTempPath(), $"login_data_{Guid.NewGuid()}.db");
                File.Copy(loginDataPath, tempFile, true);
                Console.WriteLine($"✅ Database copied to: {tempFile}");

                // Try multiple decryption methods
                TryAllDecryptionMethods(tempFile, decryptionKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static byte[] GetDecryptionKey(string localStatePath)
        {
            try
            {
                string localStateJson = File.ReadAllText(localStatePath);
                JObject localState = JObject.Parse(localStateJson);

                string encryptedKeyBase64 = localState["os_crypt"]?["encrypted_key"]?.ToString();

                if (string.IsNullOrEmpty(encryptedKeyBase64))
                    return null;

                byte[] encryptedKeyWithPrefix = Convert.FromBase64String(encryptedKeyBase64);

                if (encryptedKeyWithPrefix.Length > 5 &&
                    encryptedKeyWithPrefix[0] == 'D' &&
                    encryptedKeyWithPrefix[1] == 'P' &&
                    encryptedKeyWithPrefix[2] == 'A' &&
                    encryptedKeyWithPrefix[3] == 'P' &&
                    encryptedKeyWithPrefix[4] == 'I')
                {
                    byte[] encryptedKey = new byte[encryptedKeyWithPrefix.Length - 5];
                    Array.Copy(encryptedKeyWithPrefix, 5, encryptedKey, 0, encryptedKey.Length);

                    return ProtectedData.Unprotect(encryptedKey, null, DataProtectionScope.CurrentUser);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Key error: {ex.Message}");
                return null;
            }
        }

        static void TryAllDecryptionMethods(string dbPath, byte[] key)
        {
            try
            {
                string connectionString = $"Data Source={dbPath};Mode=ReadOnly;Pooling=False";

                using (var conn = new SqliteConnection(connectionString))
                {
                    conn.Open();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT origin_url, username_value, password_value FROM logins WHERE password_value IS NOT NULL";

                    using (var reader = cmd.ExecuteReader())
                    {
                        int count = 0;

                        while (reader.Read())
                        {
                            count++;

                            string url = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            string username = reader.IsDBNull(1) ? "" : reader.GetString(1);

                            byte[] encryptedData = null;
                            if (!reader.IsDBNull(2))
                            {
                                using (var stream = reader.GetStream(2))
                                using (var ms = new MemoryStream())
                                {
                                    stream.CopyTo(ms);
                                    encryptedData = ms.ToArray();
                                }
                            }

                            Console.WriteLine($"\n{'='.ToString().PadRight(80, '=')}");
                            Console.WriteLine($"🔐 ENTRY #{count}");
                            Console.WriteLine($"🌐 URL: {url}");
                            Console.WriteLine($"👤 Username: {username}");

                            if (encryptedData == null || encryptedData.Length == 0)
                            {
                                Console.WriteLine("❌ No encrypted data");
                                continue;
                            }

                            Console.WriteLine($"\n📊 Encrypted Data Analysis:");
                            Console.WriteLine($"   Total Length: {encryptedData.Length} bytes");
                            Console.WriteLine($"   Hex Dump: {BitConverter.ToString(encryptedData).Replace("-", " ")}");

                            // Try all possible methods
                            Console.WriteLine($"\n🔬 Trying ALL decryption methods:");

                            // Method 1: Standard Chrome format (v10/v11/v20)
                            TryMethod1(encryptedData, key);

                            // Method 2: Try different nonce positions
                            TryMethod2(encryptedData, key);

                            // Method 3: Try without version prefix
                            TryMethod3(encryptedData, key);

                            // Method 4: Try with different tag positions
                            TryMethod4(encryptedData, key);

                            // Method 5: Try BouncyCastle with various configurations
                            TryMethod5(encryptedData, key);

                            // Method 6: Try DPAPI (old format)
                            TryMethod6(encryptedData);

                            Console.WriteLine($"\n{'='.ToString().PadRight(80, '=')}");
                        }
                    }
                }
            }
            finally
            {
                try { File.Delete(dbPath); } catch { }
                Console.WriteLine("\n🧹 Temporary file cleaned up.");
            }
        }

        static void TryMethod1(byte[] data, byte[] key)
        {
            Console.WriteLine("\n📌 Method 1 - Standard Chrome Format:");
            try
            {
                if (data.Length < 3 + 12 + 16)
                {
                    Console.WriteLine("   ❌ Data too short");
                    return;
                }

                string version = Encoding.ASCII.GetString(data, 0, 3);
                Console.WriteLine($"   Version: {version}");

                byte[] nonce = new byte[12];
                Array.Copy(data, 3, nonce, 0, 12);

                int ciphertextLength = data.Length - 3 - 12 - 16;
                byte[] ciphertext = new byte[ciphertextLength];
                Array.Copy(data, 15, ciphertext, 0, ciphertextLength);

                byte[] tag = new byte[16];
                Array.Copy(data, data.Length - 16, tag, 0, 16);

                Console.WriteLine($"   Nonce: {BitConverter.ToString(nonce)}");
                Console.WriteLine($"   Ciphertext length: {ciphertextLength}");
                Console.WriteLine($"   Tag: {BitConverter.ToString(tag)}");

                using (var aes = new AesGcm(key))
                {
                    byte[] plaintext = new byte[ciphertext.Length];
                    aes.Decrypt(nonce, ciphertext, tag, plaintext);
                    string result = Encoding.UTF8.GetString(plaintext);
                    Console.WriteLine($"   ✅ SUCCESS: '{result}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }

        static void TryMethod2(byte[] data, byte[] key)
        {
            Console.WriteLine("\n📌 Method 2 - Different Nonce Position:");
            try
            {
                // Try assuming nonce starts at position 0
                if (data.Length < 12 + 16)
                {
                    Console.WriteLine("   ❌ Data too short");
                    return;
                }

                byte[] nonce = new byte[12];
                Array.Copy(data, 0, nonce, 0, 12);

                int ciphertextLength = data.Length - 12 - 16;
                byte[] ciphertext = new byte[ciphertextLength];
                Array.Copy(data, 12, ciphertext, 0, ciphertextLength);

                byte[] tag = new byte[16];
                Array.Copy(data, data.Length - 16, tag, 0, 16);

                Console.WriteLine($"   Nonce (pos 0): {BitConverter.ToString(nonce)}");

                using (var aes = new AesGcm(key))
                {
                    byte[] plaintext = new byte[ciphertext.Length];
                    aes.Decrypt(nonce, ciphertext, tag, plaintext);
                    string result = Encoding.UTF8.GetString(plaintext);
                    Console.WriteLine($"   ✅ SUCCESS: '{result}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }

        static void TryMethod3(byte[] data, byte[] key)
        {
            Console.WriteLine("\n📌 Method 3 - Try without version prefix:");
            try
            {
                if (data.Length < 12 + 16)
                {
                    Console.WriteLine("   ❌ Data too short");
                    return;
                }

                // Skip first 3 bytes (version)
                byte[] dataWithoutVersion = new byte[data.Length - 3];
                Array.Copy(data, 3, dataWithoutVersion, 0, data.Length - 3);

                byte[] nonce = new byte[12];
                Array.Copy(dataWithoutVersion, 0, nonce, 0, 12);

                int ciphertextLength = dataWithoutVersion.Length - 12 - 16;
                byte[] ciphertext = new byte[ciphertextLength];
                Array.Copy(dataWithoutVersion, 12, ciphertext, 0, ciphertextLength);

                byte[] tag = new byte[16];
                Array.Copy(dataWithoutVersion, dataWithoutVersion.Length - 16, tag, 0, 16);

                using (var aes = new AesGcm(key))
                {
                    byte[] plaintext = new byte[ciphertext.Length];
                    aes.Decrypt(nonce, ciphertext, tag, plaintext);
                    string result = Encoding.UTF8.GetString(plaintext);
                    Console.WriteLine($"   ✅ SUCCESS: '{result}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }

        static void TryMethod4(byte[] data, byte[] key)
        {
            Console.WriteLine("\n📌 Method 4 - Try with different tag positions:");
            try
            {
                if (data.Length < 3 + 12)
                {
                    Console.WriteLine("   ❌ Data too short");
                    return;
                }

                string version = Encoding.ASCII.GetString(data, 0, 3);
                byte[] nonce = new byte[12];
                Array.Copy(data, 3, nonce, 0, 12);

                // Try different tag lengths (some Chrome versions use 12-byte tag)
                int[] tagLengths = { 16, 12, 14, 15 };

                foreach (int tagLen in tagLengths)
                {
                    try
                    {
                        if (data.Length < 3 + 12 + tagLen)
                            continue;

                        int ciphertextLength = data.Length - 3 - 12 - tagLen;
                        byte[] ciphertext = new byte[ciphertextLength];
                        Array.Copy(data, 15, ciphertext, 0, ciphertextLength);

                        byte[] tag = new byte[tagLen];
                        Array.Copy(data, data.Length - tagLen, tag, 0, tagLen);

                        Console.WriteLine($"   Trying tag length: {tagLen}");

                        using (var aes = new AesGcm(key, tagLen * 8))
                        {
                            byte[] plaintext = new byte[ciphertext.Length];
                            aes.Decrypt(nonce, ciphertext, tag, plaintext);
                            string result = Encoding.UTF8.GetString(plaintext);
                            Console.WriteLine($"   ✅ SUCCESS (tag len {tagLen}): '{result}'");
                            return;
                        }
                    }
                    catch
                    {
                        // Continue to next tag length
                    }
                }
                Console.WriteLine($"   ❌ All tag lengths failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }

        static void TryMethod5(byte[] data, byte[] key)
        {
            Console.WriteLine("\n📌 Method 5 - BouncyCastle with various configs:");
            try
            {
                if (data.Length < 3 + 12 + 16)
                {
                    Console.WriteLine("   ❌ Data too short");
                    return;
                }

                byte[] nonce = new byte[12];
                Array.Copy(data, 3, nonce, 0, 12);

                int ciphertextLength = data.Length - 3 - 12 - 16;
                byte[] ciphertext = new byte[ciphertextLength];
                Array.Copy(data, 15, ciphertext, 0, ciphertextLength);

                byte[] tag = new byte[16];
                Array.Copy(data, data.Length - 16, tag, 0, 16);

                // Try BouncyCastle with combined ciphertext+tag
                byte[] ciphertextWithTag = new byte[ciphertext.Length + tag.Length];
                Array.Copy(ciphertext, 0, ciphertextWithTag, 0, ciphertext.Length);
                Array.Copy(tag, 0, ciphertextWithTag, ciphertext.Length, tag.Length);

                var gcmBlockCipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(key), 128, nonce);
                gcmBlockCipher.Init(false, parameters);

                byte[] plaintext = new byte[gcmBlockCipher.GetOutputSize(ciphertextWithTag.Length)];
                int len = gcmBlockCipher.ProcessBytes(ciphertextWithTag, 0, ciphertextWithTag.Length, plaintext, 0);
                len += gcmBlockCipher.DoFinal(plaintext, len);

                byte[] result = new byte[len];
                Array.Copy(plaintext, 0, result, 0, len);

                Console.WriteLine($"   ✅ SUCCESS: '{Encoding.UTF8.GetString(result)}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }

        static void TryMethod6(byte[] data)
        {
            Console.WriteLine("\n📌 Method 6 - DPAPI (old format):");
            try
            {
                byte[] decryptedData = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
                string result = Encoding.UTF8.GetString(decryptedData);
                Console.WriteLine($"   ✅ SUCCESS: '{result}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Failed: {ex.Message}");
            }
        }
    }
}