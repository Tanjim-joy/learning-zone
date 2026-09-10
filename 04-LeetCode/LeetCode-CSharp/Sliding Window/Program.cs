/*
    Sliding Window হলো একটি খুব জনপ্রিয় algorithm technique যা সাধারণত array বা string সমস্যায় ব্যবহার করা হয়। 
    এটি বিশেষ করে তখন কাজে লাগে যখন একটি continuous subarray / substring এর উপর কাজ করতে হয়।

    এই ধারণাটি অনেক programming problem-এ ব্যবহৃত হয়, যেমন
    Longest Substring Without Repeating Characters,
    Maximum Sum Subarray ইত্যাদি।
 */

using System;
using System.Collections.Generic;

namespace Sliding_WindowSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 1, 5, 1, 3, 2 };
            int k = 3;

            int maxsum = 0;

            for (int i = 0; i <= arr.Length-k; i++) 
            {
                int sum = 0;

                for (int j = i; j < i+k; j++)
                {
                    sum += arr[j];
                }

                maxsum = Math.Max(maxsum, sum);
            }

            Console.WriteLine("Maximum sum of a subarray of size " + k + " is: " + maxsum);

            // using sliding window technique to string pattern 

            string str = "abcdabcbb";

            Dictionary<char, int> charIndxMap = new Dictionary<char, int>();

            int maxLength = 0;
            int left = 0;
            int right = 0;
            int startIndex = 0;
            while (right < str.Length)
            {   
                char currentChar = str[right];
                if (charIndxMap.ContainsKey(currentChar) && charIndxMap[currentChar] >= left)
                {
                    left = charIndxMap[currentChar] + 1;
                }
                charIndxMap[currentChar] = right;

                //maxLength = Math.Max(maxLength, right - left + 1);
                if (right - left + 1 > maxLength)
                {
                    maxLength = right - left + 1;
                    startIndex = left;
                }

                right++;
            }

            Console.WriteLine($"Length of the longest substring without repeating characters is: {maxLength} + and string {str.Substring(startIndex, maxLength)}");
        }
    }
}