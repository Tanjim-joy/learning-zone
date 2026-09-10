using System.Collections.Immutable;

namespace CountAlphanumericCharacters
{
    class Program
    {
        /*
            Question:   Write a C# program that counts the number of alphanumeric characters in a given string.
                    Alphanumeric characters include letters (both uppercase and lowercase) and digits (0-9).
                    The program should ignore spaces, punctuation, and any other non-alphanumeric characters.

            Question: Count domain Email.

            Questions: count Letters, Digits, and Special Characters in a string.
         */
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string str = "Hello, World! 123";

            /*int count = solution.CountAlphanumeric(str);
            Console.WriteLine($"Number of alphanumeric characters: {count}");*/

            // Using Dictionary to count frequency of each alphanumeric character
            /*Dictionary<char, int> Count = new Dictionary<char, int>();
            foreach(char c in str)
            {
                //if (char.IsLetterOrDigit(c)) 
                //{
            //Count[c] = Count.ContainsKey(c) ? Count[c] + 1 : 1; // Ternary operator to simplify countin
                    if (Count.ContainsKey(c))
                    {
                        Count[c]++;
                    }
                    else
                    {
                        Count[c] = 1;
                    }
                //}
            }
            foreach (var c in Count)
            {
                Console.WriteLine($"Character: {c.Key}, Count: {c.Value}");
            }*/

            /*string domainEmail = "user1@gmail.com, user2@yahoo.com, user3@hotmail.com, user4@outlook.com, user5@gmail.com,";
            //int countDomainEmail = solution.DomainCount(domainEmail);

            Dictionary<string, int> domainCount = new Dictionary<string, int>();
            string[] email = domainEmail.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); // কমা দিয়ে স্প্লিট করে ইমেইলগুলো আলাদা করা হচ্ছে, এবং খালি এন্ট্রি বাদ দেওয়া হচ্ছে

            foreach (string e in email)
            {
                string trimmedEmail = e.Trim(); // অতিরিক্ত স্পেস থাকলে সরিয়ে দেবে
                if (string.IsNullOrEmpty(trimmedEmail)) continue;

                string[] parts = trimmedEmail.Split('@');

                if (parts.Length == 2) // নিশ্চিত হওয়া যে @ আছে এবং ডোমেইন পাওয়া গেছে
                {
                    string domain = parts[1];
                    if (domainCount.ContainsKey(domain))
                    {
                        domainCount[domain]++;
                    }
                    else
                    {
                        domainCount[domain] = 1;
                    }
                }
            }
            foreach (var kvp in domainCount)
            {
                Console.WriteLine($"Domain: {kvp.Key}, Count: {kvp.Value}");
            }*/

            Dictionary<char, int> Count = new Dictionary<char, int>();

            Console.WriteLine(str.Length);

            // count total Letters, Digits, and Special Characters in a string
            /*  foreach (char c in str)
              {
                  if (char.IsLetter(c) || char.IsDigit(c))
                  {
                      if (Count.ContainsKey(c))
                      {
                          Count[c]++;
                      }
                      else
                      {
                          Count[c] = 1;
                      }
                  }
                  else
                  {
                      if (Count.ContainsKey(c))
                      {
                          Count[c]++;
                      }
                      else
                      {
                          Count[c] = 1;
                      }
                  }
              }

              foreach (var c in Count)
              {
                  Console.WriteLine($"Character: {c.Key}, Count: {c.Value}"); Console.WriteLine(c);
              }*/


            List<string> cities = new List<string>
            {
               "Lisbon", "London", "Liverpool", "Madrid", "Milan", "Munich", "Porto", "Paris"
            };
            /*
                Grouping cities by their first letter and counting the number of cities in each group
            */
            cities.Sort(); // Sort the list of cities alphabetically
            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }

            Dictionary<char, int> cityCount = new Dictionary<char, int>();
            foreach (string city in cities)
            {
                char firstLetter = city[0]; // Get the first letter of the city name
                if (cityCount.ContainsKey(firstLetter))
                {
                    cityCount[firstLetter]++;
                }
                else
                {
                    cityCount[firstLetter] = 1;
                }
            }
            foreach (var kvp in cityCount)
            {
                Console.WriteLine($"First Letter: {kvp.Key}, Count: {kvp.Value}");
            }
        }
        public class Solution
        {
            /*public int CountAlphanumeric(string str)
            {
                int count = 0;
                foreach (char c in str)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        count++;
                    }
                }
                return count;
            }*/

            public int DomainCount(string domainEmail)
            {
                int emailCount = 0;
                int gmailCount = 0;
                int yahooCount = 0;
                int hotmailCount = 0;
                string[] emails = domainEmail.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string email in emails)
                {
                    if (email.Contains("@gmail.com"))
                    {
                        gmailCount++;
                    }
                    else if (email.EndsWith("@yahoo.com"))
                    {
                        yahooCount++;
                    }
                    else if (email.EndsWith("@hotmail.com"))
                    {
                        hotmailCount++;
                    }
                    else
                    {
                        emailCount++;
                    }
                }

                Console.WriteLine($"Total Gmail: {gmailCount++}");
                Console.WriteLine($"Total Yahoo: {yahooCount++}");
                Console.WriteLine($"Total Hotmail: {hotmailCount++}");

                return emails.Length; // Total email count
            }
        }
    }

}