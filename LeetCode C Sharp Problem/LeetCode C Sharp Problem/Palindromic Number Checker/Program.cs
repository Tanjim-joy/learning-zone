namespace PalindromicNumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            
            int number = 1331;
            string str ="aXLba";
            //Console.WriteLine("Is Palindrome: " + solution.IsPalindrome(number));
            Console.WriteLine("Reversed String: " + solution.ReverseString(str));
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
    }
}