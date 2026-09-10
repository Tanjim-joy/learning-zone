namespace PalindromicNumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            
            int number = 1331;
            string str = "babad";
            //Console.WriteLine("Is Palindrome: " + solution.IsPalindrome(number));
            Console.WriteLine("Reversed String: " + solution.LongestPalindrome(str));
        }
    }
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) // Negative numbers and numbers ending with 0 (except 0 itself) cannot be palindromes
            {
                return false;
            }
            int reversedHalf = 0;
            while (x > reversedHalf) // Reverse only half of the number
            {
                reversedHalf = reversedHalf * 10 + x % 10; // Append last digit to reversedHalf
                x /= 10; // Remove last digit from x
            }
            return x == reversedHalf || x == reversedHalf / 10; // Check for both even and odd length palindromes
        }

        public bool IsPalindromeString(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            if (str == new string(charArray))
            {
                return "The string is a palindrome.";
            }
            else
            {
                return new string(charArray) + " isn't a palindrome.";
            }
        }

        // For leetcode problem 5: Longest Palindromic Substring
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                return s;
            }

            int start = 0;
            int maxlength = 1;

            for (int i = 0; i < s.Length; i++)
            {
                // Odd length palindromes
                ExpandAroundCenter(s, i, i, ref start, ref maxlength);
                // Even length palindromes
                ExpandAroundCenter(s, i, i + 1, ref start, ref maxlength);
            }
            return s.Substring(start, maxlength);
        }
        private void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxlength)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            int length = right - left - 1;
            if (length > maxlength)
            {
                start = left + 1; 
                maxlength = length; 
            }
        }
    }
}