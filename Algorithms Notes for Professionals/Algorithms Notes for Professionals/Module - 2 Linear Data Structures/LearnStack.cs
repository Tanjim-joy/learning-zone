using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Questions for Practice:
    অপারেশনের ফলাফল বের করা: ধরুন একটি খালি স্ট্যাক m আছে। নিচের অপারেশনগুলো করার পর স্ট্যাকের শীর্ষে (Top) কোন উপাদানটি থাকবে?
    m.push('x')
    m.push('y')
    m.pop()
    m.push('z')
    m.peek()
    Answer: 'z' থাকবে। 
    describe -> স্ট্যাকের শীর্ষে থাকা উপাদানটি প্রদর্শন করা হবে। 

    Exercise: reverse a string using stack: একটি স্ট্রিং ইনপুট হিসেবে নিন এবং সেটি স্ট্যাক ব্যবহার করে উল্টে দিন। উদাহরণস্বরূপ, "hello" ইনপুট দিলে আউটপুট হবে "olleh"।
    Exercise: Balancing Brackets: একটি স্ট্রিং ইনপুট হিসেবে নিন যা বিভিন্ন ধরনের ব্র্যাকেট (যেমন (), {}, []) ধারণ করে। চেক করুন যে ব্র্যাকেটগুলো সঠিকভাবে ব্যালেন্সড আছে কিনা। 
    উদাহরণস্বরূপ, "({[]})" ইনপুট দিলে আউটপুট হবে "Balanced", আর "({[})" ইনপুট দিলে আউটপুট হবে "Not Balanced"।
    
    Exercise; সংখ্যা পদ্ধতি পরিবর্তন করা: একটি সংখ্যা ইনপুট হিসেবে নিন এবং সেটি বাইনারি, অক্টাল, বা হেক্সাডেসিমাল ফরম্যাটে রূপান্তর করুন। 
    উদাহরণস্বরূপ, 10 ইনপুট দিলে বাইনারি আউটপুট হবে "1010", অক্টাল আউটপুট হবে "12", এবং হেক্সাডেসিমাল আউটপুট হবে "A"।

 */

namespace Module___2_Linear_Data_Structures
{
    public class numberSystemConversion
    {
        Stack<int> conversionStack = new Stack<int>();
        public string convertToBinary(int number)
        {
            while (number > 0)
            {
                conversionStack.Push(number % 2);
                number /= 2;
            }
            StringBuilder binaryString = new StringBuilder();
            while (conversionStack.Count > 0)
            {
                binaryString.Append(conversionStack.Pop());
            }
            return binaryString.ToString();
        }
        public string convertToOctal(int number)
        {
            while (number > 0)
            {
                conversionStack.Push(number % 8);
                number /= 8;
            }
            StringBuilder octalString = new StringBuilder();
            while (conversionStack.Count > 0)
            {
                octalString.Append(conversionStack.Pop());
            }
            return octalString.ToString();
        }
        public string convertToHexadecimal(int number)
        {
            char[] hexDigits = "0123456789ABCDEF".ToCharArray();
            Stack<char> hexStack = new Stack<char>();
            while (number > 0)
            {
                hexStack.Push(hexDigits[number % 16]);
                number /= 16;
            }
            StringBuilder hexString = new StringBuilder();
            while (hexStack.Count > 0)
            {
                hexString.Append(hexStack.Pop());
            }
            return hexString.ToString();
        }
    }
    public class balancedBrackets<T>
    {
        Stack<T> brackets = new Stack<T>();

        public void isBalancedBracketsData(T[] input)
        {
            foreach (T item in input)
            {
                //➡️ Stack থেকে পাওয়া এলিমেন্টের সাথে অ্যারের সামনে দিকের এলিমেন্ট তুলনা করা হচ্ছে।
                
                if (item.Equals((T)(object)'(') || item.Equals((T)(object)'{') || item.Equals((T)(object)'['))
                {
                    // ⛳ যদি এলিমেন্টটি একটি খোলা ব্র্যাকেট হয়, তাহলে সেটি স্ট্যাকের মধ্যে ঢোকানো হচ্ছে।                    
                    brackets.Push(item);
                }                
                else if (item.Equals((T)(object)')') || item.Equals((T)(object)'}') || item.Equals((T)(object)']'))
                {
                    // ⛳ যদি এলিমেন্টটি একটি বন্ধ ব্র্যাকেট হয়, তাহলে স্ট্যাক থেকে শীর্ষের উপাদানটি বের করা হচ্ছে এবং সেটি ব্র্যাকেটের সাথে মিলানো হচ্ছে।
                    if (brackets.Count == 0) // ⛳ যদি স্ট্যাক খালি থাকে, তাহলে এটি একটি ব্যালেন্সড ব্র্যাকেট নয়।
                    {
                        Console.WriteLine("Not Balanced");
                        return;
                    }
                    // ⛳ স্ট্যাক থেকে শীর্ষের উপাদানটি বের করা হচ্ছে।
                    T top = brackets.Pop();

                    // ⛳ যদি ব্র্যাকেটটি সঠিকভাবে মিল না খায়, তাহলে এটি একটি ব্যালেন্সড ব্র্যাকেট নয়।
                    if ((item.Equals((T)(object)')') && !top.Equals((T)(object)'(')) ||
                        (item.Equals((T)(object)'}') && !top.Equals((T)(object)'{')) ||
                        (item.Equals((T)(object)']') && !top.Equals((T)(object)'[')))
                    {
                        // ⛳ যদি ব্র্যাকেটটি সঠিকভাবে মিল না খায়, তাহলে এটি একটি ব্যালেন্সড ব্র্যাকেট নয়।                        
                        Console.WriteLine("Not Balanced");
                        return;
                    }
                }
            }
            Console.WriteLine("Balanced");
        }
    }
    public class reverseString<T>
    {
        Stack<T> reversedata = new Stack<T>();
        public string reverse(T[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                reversedata.Push((T)(object)input[i]);
            }
            StringBuilder stringBuilder = new StringBuilder(); // StringBuilder ব্যবহার করা হচ্ছে কারণ এটি string concatenation এর জন্য efficient।
            while (reversedata.Count > 0)
            {
                // স্ট্যাকের শীর্ষের উপাদানটি বের করা হচ্ছে এবং সেটি স্ট্রিং বিল্ডারে যোগ করা হচ্ছে 
                // ➡️ Stack থেকে পাওয়া এলিমেন্টের সাথে অ্যারের সামনে দিকের এলিমেন্ট তুলনা করা হচ্ছে।
                
                stringBuilder.Append(reversedata.Pop());
                // ➡️ Stack থেকে পাওয়া এলিমেন্টের সাথে অ্যারের সামনে দিকের এলিমেন্ট তুলনা করা হচ্ছে।

            }
            return stringBuilder.ToString();                      
        }
    }
    public class questions_1
    {
        Stack<int> value = new Stack<int>();
        // pop push peek এর মাধ্যমে স্ট্যাকের অপারেশনগুলো করা হচ্ছে।
        public void stackOperations()
        {
            value.Push(1);
            value.Push(2);
            value.Pop();
            value.Push(3);
            Console.WriteLine(value.Peek()); // স্ট্যাকের শীর্ষে থাকা উপাদানটি প্রদর্শন করা হবে।
        }
    }
    public class LearnStack<T> // জেনেরিক স্ট্যাক ক্লাস
    {
        // ➡️ <T> মানে হলো: এই ক্লাস যেকোনো ডেটা টাইপ (int, char, string ইত্যাদি) নিয়ে কাজ করতে পারবে।
        // Palindrome Number Check      
        public string Ispalindrome(T[] items) // T[] items মানে: যেকোনো টাইপের একটি array ইনপুট নেবে।
        {
            Stack<T> myStack = new Stack<T>();

            for (int i = 0; i < items.Length; i++)
            {
                myStack.Push((T)(object)items[i]);
            }
            /* 
                ➡️ for লুপ দিয়ে items অ্যারের প্রতিটি এলিমেন্ট Stack-এ ঢোকানো হচ্ছে।
                ➡️ (T)(object) দিয়ে forcefully type casting করা হচ্ছে।                
             */

            bool isPalindrome = true; // প্যালিনড্রোম চেক করার জন্য একটি ফ্ল্যাগ
            int pos = 0;  // স্ট্রিংয়ের পজিশন ট্র্যাক করার জন্য একটি ভেরিয়েবল

            while (myStack.Count > 0)
            {
                T top = (T)myStack.Pop();
                /*
                    ➡️ Stack-এর উপরের এলিমেন্টটি বের করা হচ্ছে (Pop)।
                    ➡️ Pop মানে: শেষে ঢোকানো ডেটা আগে বের হবে।
                 */
                if (!top.Equals((T)(object)items[pos]))
                {
                    isPalindrome = false;
                    break;
                }
                /*
                    ➡️ Stack থেকে পাওয়া এলিমেন্টের সাথে
                    ➡️ অ্যারের সামনে দিকের এলিমেন্ট তুলনা করা হচ্ছে।
                    ➡️ .Equals() দিয়ে value comparison করা হচ্ছে।
                    ➡️ যদি দুটি মান সমান না হয়, তাহলে এটি Palindrome নয়।
                    ➡️ break দিয়ে লুপ থামিয়ে দেওয়া হচ্ছে।
                 */
                pos++; // ➡️ অ্যারের পরবর্তী index-এ যাওয়ার জন্য pos বাড়ানো হচ্ছে।
            }

            return isPalindrome ? "Palindrome" : "Not Palindrome";
        }
    }
}

