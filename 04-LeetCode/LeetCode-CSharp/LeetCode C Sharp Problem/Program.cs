using System;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {            
            Solution solution = new Solution();

            string input1 = "abcabcbb";
            int result1 = solution.LengthOfLongestSubstring(input1);
            Console.WriteLine($"Input: {input1} -> Output: {result1}");

            string input2 = "bbbbb";
            int result2 = solution.LengthOfLongestSubstring(input2);
            Console.WriteLine($"Input: {input2} -> Output: {result2}");

            string input3 = "pwwkew";
            int result3 = solution.LengthOfLongestSubstring(input3);
            Console.WriteLine($"Input: {input3} -> Output: {result3}");
        }
    }
    // Sol -> 01
    /*public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charIndex = new Dictionary<char, int>();
            int maxLength = 0;
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                if (charIndex.ContainsKey(currentChar) && charIndex[currentChar] >= left)
                {
                    left = charIndex[currentChar] + 1;
                }

                charIndex[currentChar] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }*/

    // Sol -> 02
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charindex = new Dictionary<char, int>();

            int maxLength = 0; 
            int left = 0; 

            for(int right = 0; right < s.Length; right++)
            {
                char curentChar = s[right]; 
                
                if ( charindex.ContainsKey(curentChar) && charindex[curentChar] >= left)
                {
                    left = charindex[curentChar] + 1;
                }
                charindex[curentChar] = right; 
                maxLength = Math.Max(maxLength, right - left + 1); 
            }

            return maxLength;
        }
    }
}


/*
    1. right = 0 ('a'): charIndex {'a':0}, left=0, maxLength=1
    2. right = 1 ('b'): charIndex {'a':0,'b':1}, left=0, maxLength=2
    3. right = 2 ('c'): charIndex {'a':0,'b':1,'c':2}, left=0, maxLength=3
    4. right = 3 ('a'): 'a' আগে দেখা গেছে (index 0) এবং left <= 0
       left = 0 + 1 = 1
       charIndex {'a':3,'b':1,'c':2}, maxLength=3
    5. right = 4 ('b'): 'b' আগে দেখা গেছে (index 1) এবং left <= 1
       left = 1 + 1 = 2
       charIndex {'a':3,'b':4,'c':2}, maxLength=3
    6. right = 5 ('c'): 'c' আগে দেখা গেছে (index 2) এবং left <= 2
       left = 2 + 1 = 3
       charIndex {'a':3,'b':4,'c':5}, maxLength=3
    7. right = 6 ('b'): 'b' আগে দেখা গেছে (index 4) এবং left <= 4
       left = 4 + 1 = 5
       charIndex {'a':3,'b':6,'c':5}, maxLength=3
    8. right = 7 ('b'): 'b' আগে দেখা গেছে (index 6) এবং left <= 6
       left = 6 + 1 = 7
       charIndex {'a':3,'b':7,'c':5}, maxLength=3
*/
