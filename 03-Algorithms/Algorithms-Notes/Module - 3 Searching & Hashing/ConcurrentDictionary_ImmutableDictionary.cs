using Stripe;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Module___3_Searching___Hashing
{
    /*
    
        কখন কী ব্যবহার করবেন:

            সিচুয়েশন	                                ব্যবহার করবেন
            সিঙ্গেল থ্রেড, দ্রুত দরকার	                Dictionary
            মাল্টি থ্রেড, অনেক রাইট	                    ConcurrentDictionary
            মাল্টি থ্রেড, শুধু রিড	                    ImmutableDictionary
            ক্যাশিং, একবার লোড পরে শুধু রিড	        ImmutableDictionary
            ইতিহাস ট্র্যাক করতে হবে	                    ImmutableDictionary
            রিয়েল-টাইম ডাটা স্ট্রিম	                    ConcurrentDictionary
    

        ডিকশনারি টাইপ	            প্রধান বৈশিষ্ট্য	                            ব্যবহারের স্থান
        Dictionary	                দ্রুত, থ্রেড-সেফ না	                        সিঙ্গেল থ্রেড অ্যাপ, ওয়েব রিকোয়েস্ট পার থ্রেডেড
        ConcurrentDictionary	    থ্রেড-সেফ, ফাইন-গ্রেইন লক	                ওয়েব অ্যাপ ক্যাশ, রিয়েল-টাইম ডাটা, ব্যাংকিং
        ImmutableDictionary	        ইমিউটেবল, স্ট্রাকচারাল শেয়ারিং	            কনফিগারেশন, হিস্ট্রি, ফাংশনাল প্রোগ্রামিং

    মনে রাখবেন: সঠিক টুল বেছে নেওয়াই দক্ষ ডেভেলপারের লক্ষণ। সব সময় Dictionary দিয়ে শুরু করুন। থ্রেড ইস্যু আসলে ConcurrentDictionary-এ 
    আপগ্রেড করুন। ইতিহাস বা কনফিগারেশন হলে ImmutableDictionary ব্যবহার করুন।
    */
    internal class ConcurrentDictionaryLeraning
    {
        /*  ConcurrentDictionary is a thread-safe collection that allows concurrent read and write operations without
            the need for external synchronization. It is part of the System.Collections.Concurrent namespace and is designed to
            handle high levels of concurrency efficiently.
         */
        // Danger Code

        //public void ConcurrentDictionaryLearning()
        //{
        //    var dict = new Dictionary<string, int>();

        //    Parallel.For(0, 1000, i =>
        //    {
        //        dict["key"] = i; // 💥 Exception: "Operation may destabilize the dictionary"
        //    });
        //    Console.WriteLine($"Total Items: {dict.Count}");
        //    Console.WriteLine($"Value: {dict["key"]}");
        //}

        //public void ConcurrentDictionaryLearning()
        //{
        //    var concurrent = new ConcurrentDictionary<string, int>(); // ✅ Thread-safe
        //    Parallel.For(0, 1000, i =>
        //    {
        //        concurrent["key"] = i; // ✅ No exception, thread-safe
        //    });

        //    Console.WriteLine($"Total Items: {concurrent.Count}");
        //    Console.WriteLine($"Value: {concurrent["key"]}");
        //}               
    }

    public class Bank
    {
        // ✅ decimal ব্যবহার করা হলো
        private ConcurrentDictionary<string, decimal> accounts
                         = new ConcurrentDictionary<string, decimal>();

        // ✅ Deposit ঠিক করা হলো
        public void Deposit(string accountId, decimal amount)  // typo ঠিক
        {
            if (amount <= 0)
            {
                Console.WriteLine("❌ If Balance Zero!");
                return;
            }
            accounts.AddOrUpdate(
                accountId,
                amount,                              // ✅ cast নেই
                (key, oldValue) => oldValue + amount // ✅ cast নেই
            );
            Console.WriteLine($"✅ {amount} Deposited. Balance: {accounts[accountId]}");
        }

        // ✅ Withdraw সম্পূর্ণ ঠিক করা হলো
        public bool Withdraw(string accountId, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("❌ Withdraw amount greater than zero!");
                return false;
            }

            while (true) // ✅ Retry loop
            {
                // ✅ একবার পড়া
                if (!accounts.TryGetValue(accountId, out decimal currentBalance))
                {
                    Console.WriteLine("❌ Account Null");
                    return false;
                }

                // ✅ Balance চেক
                if (currentBalance < amount)
                {
                    Console.WriteLine("❌ no balance");
                    return false;
                }

                decimal newBalance = currentBalance - amount; // ✅ decimal

                // ✅ একই currentBalance দিয়ে TryUpdate
                if (accounts.TryUpdate(accountId, newBalance, currentBalance))
                {
                    Console.WriteLine($"Withdraw {amount} cash। balance {newBalance}");
                    return true;
                }
                // ✅ ব্যর্থ হলে আবার চেষ্টা
                Console.WriteLine(" try again later...");
            }
        }

        // ✅ GetBalance ঠিক করা হলো
        public decimal GetBalance(string accountId)
        {
            return accounts.TryGetValue(accountId, out decimal balance)
                   ? balance : 0; // ✅ decimal সব জায়গায়
        }
    }

    public class ImmutableDictionaryLearning
    {
        /*  ImmutableDictionary is a collection that cannot be modified after it is created. 
            It is part of the System.Collections.Immutable namespace and provides thread-safe read operations without the need for locks.
         */
        public void ImmutableDictionaryLearnings()
        {
            var dict = ImmutableDictionary.Create<string, int>();
            dict = dict.Add("key1", 1);
            dict = dict.Add("key2", 2);
            dict = dict.Add("key3", 3);
            Console.WriteLine($"Total Items: {dict.Count}");           

            dict = dict.SetItem("key1", 10); // ✅ Update existing key
            Console.WriteLine($"Updated key1: {dict["key1"]}");

            dict = dict.Remove("key2"); // ✅ Remove key
            Console.WriteLine($"Total Items: {dict.Count}");

            dict = dict.Add("key4", 4); // ✅ Add new key
            Console.WriteLine($"Total Items: {dict.Count}");

            Console.WriteLine($"Value: {dict["key1"]}");
        }
    }
}

