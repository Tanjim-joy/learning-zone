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