using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Learning
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            if(digits == null || digits.Length == 0)
            {
                return new int[] { 1 };
            }

            List<int> digitList = digits.ToList();
            int carry = 1;

            for (int i= digitList.Count -1; i >= 0 && carry > 0; i--  )
            {
                int sum = digitList[i] + carry;
                digitList[i] = sum % 10;
                carry = sum / 10;
            }
            if (carry > 0)
            {
                digitList.Insert(0, carry);
            }
            return digitList.ToArray();

        }

    
        /*public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            // 2. স্ট্রিংকে স্পেস দিয়ে ভাগ করে শব্দগুলোর অ্যারে বানানো
            // StringSplitOptions.RemoveEmptyEntries - খালি এন্ট্রি বাদ দেয়
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Split the string into words, removing empty entries
            return words.Length == 0 ? 0 : words[words.Length - 1].Length; // Return the length of the last word, or 0 if there are no words
            //return words.Length == 0 ? 0 : words[^1].Length; // Return the length of the last word, or 0 if there are no words
        }*/

        /*public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int left = 0;
            int right = nums.Length - 1; ;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < target) 
                {
                    left = mid + 1;
                } 
                else if (nums[mid] > target) 
                {
                    right = mid - 1;
                }
                else 
                {
                   Console.WriteLine(mid);
                   return mid;
                }
            }
            Console.WriteLine(left);
            return left;
        }*/

        /*public int StrStr(string haystack, string needle) 
        { 
            if (needle == "")
            {
                return 0;
            }
            if (haystack.Length < needle.Length)
            {
                return -1;
            }
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }            
            return -1;
        }*/

        /*public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int count = 0;
            for (int  i= 0; i < nums.Length; i++) 
            {
                if (nums[i] != val)
                {
                    nums[count] = nums[i];
                    count++;
                }    
            }
            Console.Write($"{count} , num =[ ");
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < count)
                {
                    Console.Write(nums[i]);
                }
                else
                {
                    Console.Write("_");
                }
                if (i < nums.Length - 1)
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
            return count;
        }*/

        /*public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int uniqueCount = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[uniqueCount - 1])
                {
                    nums[uniqueCount] = nums[i];
                    uniqueCount++;
                }
                
            }
            Console.Write($"{uniqueCount} nums = [");
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < uniqueCount)
                {
                    Console.Write(nums[i]);
                }
                else
                {
                    Console.Write("_");
                }
                if (i < nums.Length - 1)
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
            return uniqueCount;
        }*/
        /*public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0); // Dummy head to simplify edge cases
            ListNode current = dummyHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            if (l1 != null)
            {
                current.next = l1;
            }
            if (l2 != null)
            {
                current.next = l2;
            }
            return dummyHead.next;
        }*/

        /*public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add(')', '(');
            map.Add('}', '{');
            map.Add(']', '[');
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    char topElement = stack.Count == 0 ? '#' : stack.Pop();
                    if (topElement != map[c])
                    {
                        Console.WriteLine($"{s} is not valid");
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            Console.WriteLine($"{s} is {(stack.Count == 0 ? "valid" : "not valid")}");
            return stack.Count == 0;
        }*/

        /*public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix))
                    {
                        return "";
                    }
                }
            }
            Console.WriteLine($"Longest common prefix: {prefix}");
            return prefix;
        }*/

        /*public int RomanToInt(string s)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>();
            romanMap.Add('I', 1);
            romanMap.Add('V', 5);
            romanMap.Add('X', 10);
            romanMap.Add('L', 50);
            romanMap.Add('C', 100);
            romanMap.Add('D', 500);
            romanMap.Add('M', 1000);

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (i < s.Length - 1 && romanMap[current] < romanMap[s[i + 1]]) { 
                    result -= romanMap[current];
                }
                else
                {
                    result += romanMap[current];
                }
            }
            Console.WriteLine(result);
            return result;

        }*/
        /*public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            if (x > 1)
            {
                string original = x.ToString();
                char[] charArray = original.ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);
                Console.WriteLine($"{original} is {(original == reversed ? "" : "not ")}a palindrome");
                return original == reversed;
            }
            return true;
        }*/
        /*public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            if (x > 1)
            {
                int original = x;
                int reversed = 0;
                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; 
                    x /= 10;
                }
                Console.WriteLine($"{original} is {(original == reversed ? "" : "not ")}a palindrome");
                return original == reversed;
            }
            return true;
        }*/

        /*public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode curr = dummyHead;
            int carry = 0;

            while(l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
            }
            
            return dummyHead.next;
        }*/

        /*public int[] TwoSum(int[] nums, int target)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {                        
                        result.Add(i);
                        result.Add(j);                        
                        break;
                    }
                }
            }
            //Console.WriteLine(string.Join(" ", result));
            return result.ToArray();

        }*/
    }
}

/*public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}*/

//public class ListNode
//{
//    public int val;
//    public ListNode next;
//    public ListNode(int x) { val = x; }
//}
/*
 2.  Add Two Numbers
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order,
and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 1. Two Sum
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order. 
 */