using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Learning
{
    public class Solution
    {
        public bool IsValid(string s)
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
        }

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
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}
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