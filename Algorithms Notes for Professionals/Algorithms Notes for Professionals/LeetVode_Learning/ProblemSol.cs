using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Learning
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
        }

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