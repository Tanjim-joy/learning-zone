using System;
using System.Collections.Generic;
using System.Text;

namespace Module___3_Searching___Hashing
{
    public class BinarySearch
    {
        public bool binarySearch(int[] number, int target)
        {
            int left = 0;
            int right = number.Length - 1;
            int countstep = 0;

            while (left <= right)
            {
                countstep++;
                int mid = left + (right - left) / 2; // Calculate the middle index to avoid potential overflow
                if (number[mid] == target)
                {
                    Console.WriteLine($"{target} -> Number found in the list & total steps: {countstep}");
                    return true;
                }
                else if (number[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {                  
                   right = mid - 1;
                }
            }
            Console.WriteLine($"{target} -> Number not found in the list");
            return false;
        }
        
    }

    public class HashSlotCalculator
    {

    }
    public class SearchingAlgorithms
    {

        public class UnsortedList
        {
            private List<int> list = new List<int>();

            public UnsortedList(int[] numbers)
            {
                list = new List<int>(numbers); // Accept an array of numbers to initialize the list
            }
            public void add(int number)
            {
                list.Add(number);
                Console.WriteLine($"{number} -> Number added to the list");
            }
            public bool linearSearch(int target)
            {
                foreach (int item in list)
                {
                    if (item == target)
                    {
                        Console.WriteLine($"{target} -> Number found in the list");
                        return true;
                    }
                }
                Console.WriteLine($"{target} -> Number not found in the list");
                return false;
            }
            /*

                খুব ভালো প্রশ্ন 👍
    এই constructor টা **না দিলে কেন সমস্যা হচ্ছিল**, সেটা আমি একদম **root-level** থেকে ধাপে ধাপে বুঝাচ্ছি।
    ---

    ## 🔹 মূল কোডটা আবার দেখি

    ```csharp
    public UnsortedList(int[] numbers)
    {
        list = new List<int>(numbers);
    }
    ```

    এই constructor–এর কাজ:
    👉 **একসাথে অনেকগুলো সংখ্যা (array) নিয়ে list initialize করা**

    ---

    ## 🔴 এই constructor না দিলে কী হচ্ছিল?

    আপনি আগে এভাবে object বানাতে চেয়েছিলেন 👇

    ```csharp
    int[] number = { 52, 14, 7, 23, 5 };
    UnsortedList unsortedList = new UnsortedList(number);
    ```

    কিন্তু আপনার ক্লাসে তখন ছিল শুধু এটা:

    ```csharp
    public class UnsortedList
    {
        private List<int> list = new List<int>();
    }
    ```

    👉 এখানে **কোনো constructor নেই যেটা `int[]` নেয়**।

    ---

    ## 🧠 C# Compiler কী করে?

    C#–এর নিয়ম:

    > যখন আপনি `new ClassName(...)` লেখেন, তখন compiler খুঁজে:
    > 👉 এমন constructor আছে কি না, যেটার parameter টাইপ মিলছে

    ### আপনার ক্ষেত্রে:

    * আপনি পাঠাচ্ছেন → `int[]`
    * Class–এ constructor আছে → ❌ নেই (বা default constructor)

    👉 তাই compiler বলে:

    ```text
    Argument 1: cannot convert from 'int[]' to 'int'
    ```

    বা

    ```text
    No constructor takes 1 argument
    ```

    ---

    ## 🔍 Default Constructor কেন কাজ করছিল না?

    এই constructor automatically থাকে:

    ```csharp
    public UnsortedList() { }
    ```

    কিন্তু আপনি যেটা call করেছেন:

    ```csharp
    new UnsortedList(number)
    ```

    ❌ Default constructor কোনো argument নেয় না
    ❌ আপনি argument পাঠাচ্ছেন

    👉 mismatch → error

    ---

    ## 📦 Constructor ছাড়া Data কোথায় যাচ্ছিল?

    Constructor না থাকলে:

    * list তৈরি হচ্ছিল খালি (`new List<int>()`)
    * array এর values **কোথাও যাচ্ছে না**
    * Search করলে list ফাঁকা থাকত

    ```csharp
    UnsortedList list = new UnsortedList();
    list.LinearSearch(23); // সবসময় false
    ```

    ---

    ## ✅ এই constructor দিলে কী লাভ হলো?

    ```csharp
    public UnsortedList(int[] numbers)
    {
        list = new List<int>(numbers);
    }
    ```

    ✔ array → List এ convert হচ্ছে
    ✔ object তৈরি হওয়ার সময়ই data ঢুকে যাচ্ছে
    ✔ extra `Add()` call দরকার নেই
    ✔ cleaner & safer design

    ---

    ## 🧩 Visual Flow (সহজ করে)

    ### ❌ Constructor ছাড়া

    ```
    Array → ❌ nowhere
    UnsortedList → empty list
    Search → always false
    ```

    ### ✅ Constructor সহ

    ```
    Array → Constructor → List<int>
    UnsortedList → populated list
    Search → correct result
    ```

    ---

    ## 🔑 সংক্ষেপে এক লাইনে

    > **Constructor না থাকায় object তৈরি করার সময় array গ্রহণ করার কোনো পথই ছিল না।**

    ---

    ## 🎯 আপনি এখন চাইলে আমি দেখাতে পারি:

    * 🔍 Constructor overloading (multiple constructors)
    * 🧪 Unit test দিয়ে প্রমাণ
    * 📘 Binary Search version
    * 🌳 BST implementation

    বলুন, পরের ধাপ কোনটা করবেন?


            */
        }

        // Lincar (Sequential) Search
        /*
         1. Linear (Sequential) Search
        Linear Search হলো সবচেয়ে সহজ সার্চিং পদ্ধতি। এতে ডেটার প্রতিটি উপাদান (element) একে একে পরীক্ষা করা হয় যতক্ষণ না কাঙ্ক্ষিত আইটেমটি পাওয়া যায় অথবা পুরো লিস্ট শেষ হয়ে যায়।

        কিভাবে কাজ করে:
        অ্যালগরিদমটি প্রথম ইনডেক্স থেকে শুরু করে ধারাবাহিকভাবে (sequentially) লিস্টের শেষ পর্যন্ত এগোয়।
        Ordered বনাম Unordered List:
        Unordered list–এ আইটেম না পাওয়া গেলে পুরো লিস্ট শেষ পর্যন্ত চেক করতে হয়।
        Ordered list–এ যদি এমন কোনো এলিমেন্ট পাওয়া যায় যা key-এর চেয়ে বড়, তাহলে সেখানেই সার্চ বন্ধ করা যায়, কারণ তার পরের কোনো এলিমেন্টই key হতে পারে না।
        Self-Organizing Data:
        এই কৌশলে যেসব আইটেম বারবার সার্চ করা হয়, সেগুলোকে লিস্টের সামনে নিয়ে আসা হয়। ফলে সময়ের সাথে সাথে গড় (average) comparison কমে যায়।
        Complexity (সময় জটিলতা):
        Worst case: O(n) → আইটেমটি শেষে আছে বা একেবারেই নেই
        Best case: O(1) → আইটেমটি প্রথম অবস্থানেই আছে
         
        */
        // =============================Exercise 1: Linear Search Concepts
        /*“80–20” Rule:
        Self-organizing list কীভাবে Pareto distribution ব্যবহার করে sequential search–এর পারফরম্যান্স বাড়ায় তা ব্যাখ্যা করুন।
        Ordered List Advantage:
        তালিকা ``–এ key 13 নেই—এটা নিশ্চিত হতে ঠিক কয়টি comparison লাগবে?*/

        public class SelfOrganizingList
        {
            private List<string> list = new List<string>();
            private Dictionary<string, int> accessCount = new Dictionary<string, int>();

            public bool searchMoveToFront(string key)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == key)
                    {
                        // Move to front
                        string foundItem = list[i];
                        list.RemoveAt(i);
                        list.Insert(0, foundItem);
                        return true;
                    }
                }
                return false;
            }
        }

    }

    /*
     
    ১. লিনিয়ার সার্চ বা সিকোয়েন্সিয়াল সার্চ (Linear or Sequential Search)
        এটি অনুসন্ধানের সবচেয়ে সহজ পদ্ধতি, যেখানে তালিকার শুরু থেকে শেষ পর্যন্ত প্রতিটি উপাদান একে একে পরীক্ষা করা হয় ।
    কাজের পদ্ধতি: অনুসন্ধানের জন্য প্রতিটি Drawer বা ইনডেক্স একটির পর একটি চেক করা হয় যতক্ষণ না কাঙ্ক্ষিত তথ্যটি পাওয়া যায় ।
    উপযোগিতা: এটি মূলত অগোছালো বা এলোমেলো (Unordered) ডাটার ক্ষেত্রে ব্যবহৃত হয় ।    
    সময় জটিলতা:
    ওরস্ট কেস (Worst Case): O(n), যখন উপাদানটি তালিকার শেষে থাকে বা আদৌ থাকে না ।
    বেস্ট কেস (Best Case): O(1), যদি প্রথম উপাদানের সাথেই মিল পাওয়া যায়।
    উন্নতি (Self-Organization): ঘন ঘন খোঁজা হয় এমন তথ্যগুলোকে তালিকার শুরুতে নিয়ে এসে এর গতি বাড়ানো সম্ভব।
    ======================================================================================================================================
    ২. বাইনারি সার্চ (Binary Search)
        এটি একটি অত্যন্ত দক্ষ অ্যালগরিদম যা 'ডিভাইড অ্যান্ড কনকার' (Divide and Conquer) কৌশল ব্যবহার করে।
    পূর্বশর্ত: এই পদ্ধতি ব্যবহারের জন্য ডাটা অবশ্যই সর্টেড (Sorted) বা সাজানো থাকতে হবে।
    কাজের পদ্ধতি: এটি সরাসরি তালিকার মাঝখানের উপাদানের সাথে তুলনা করে। যদি মাঝখানের মানটি কাঙ্ক্ষিত মানের চেয়ে ছোট হয়, তবে বাম পাশের অর্ধেক বাদ দিয়ে ডান পাশের অর্ধেকের মধ্যে অনুসন্ধান চলে। এভাবে প্রতি ধাপে সার্চ এরিয়া অর্ধেক হয়ে যায়।
    সময় জটিলতা: এর ওরস্ট কেস সময় জটিলতা হলো O(logn)। যেমন—১,০০০,০০০ উপাদানের তালিকায় লিনিয়ার সার্চে ১০ লাখ তুলনা লাগতে পারে, কিন্তু বাইনারি সার্চে মাত্র ২০টি তুলনাই যথেষ্ট।
    ======================================================================================================================================
    ৩. হ্যাশিং (Hashing)
        হ্যাশ টেবিল ব্যবহারের মাধ্যমে গড়ে O(1) বা ধ্রুবক সময়ে তথ্য খুঁজে বের করা সম্ভব 
    পদ্ধতি: এখানে একটি 'হ্যাশ ফাংশন' ব্যবহার করে 'কী' (Key)-কে একটি ইন্টিজার ইনডেক্সে রূপান্তর করা হয় এবং সরাসরি ওই ঠিকানায় তথ্যটি পাওয়া যায় [৪৫৪, ৫৫৬, ৭৬০]।
    ট্রেড-অফ: দ্রুত গতির বিনিময়ে এখানে কিছু অতিরিক্ত মেমরি ব্যবহার করতে হয় ।
    ======================================================================================================================================
    ৪. বাইনারি সার্চ ট্রি (BST) সার্চিং
    এটি একটি নন-লিনিয়ার ডাটা স্ট্রাকচার যা স্তরভিত্তিক অনুসন্ধানের সুবিধা দেয় ।
    পদ্ধতি: গাছের প্রতিটি নোডের বাম দিকের সন্তান (Child) নোডের মান ছোট এবং ডান দিকের সন্তান নোডের মান বড় হয়। কাঙ্ক্ষিত মানের সাথে তুলনা করে বারবার বাম বা ডান দিকে সরে গিয়ে অনুসন্ধান চালানো হয় [৪৯২, ৭৮৬]।
    দক্ষতা: যদি গাছটি সুষম বা ব্যালেন্সড থাকে, তবে অনুসন্ধান করতে O(logn) সময় লাগে । তবে গাছটি যদি একমুখী বা আঁকাবাঁকা (Skewed) হয়, তবে তা লিনিয়ার সার্চের মতোই O(n) সময় নিতে পারে [৫০০, ৭৯৯]।
    সংক্ষেপে তুলনা:
    অগোছালো ডাটার জন্য লিনিয়ার সার্চ শ্রেষ্ঠ ।
    সাজানো বড় ডাটার জন্য বাইনারি সার্চ অত্যন্ত কার্যকর ।
    তাৎক্ষণিক অনুসন্ধানের প্রয়োজন হলে হ্যাশিং সবচেয়ে ভালো সমাধান।       
     */
}
