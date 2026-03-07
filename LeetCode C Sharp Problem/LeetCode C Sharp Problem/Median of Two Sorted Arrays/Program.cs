using System;
using System.Collections.Generic;

/*
 Pseudocode 
`
function মধ্যমা_নির্ণয়(nums1, nums2):
    যদি nums1 এর দৈর্ঘ্য > nums2 এর দৈর্ঘ্য:
        nums1 ও nums2 অদলবদল কর (nums1 ছোট রাখতে হবে)

    m = nums1.length
    n = nums2.length
    low = 0
    high = m
    totalLeft = (m + n + 1) // 2

    যতক্ষণ low <= high:
        i = (low + high) // 2         // nums1 থেকে কতগুলি বামে নেব
        j = totalLeft − i              // nums2 থেকে কতগুলি বামে নেব

        L1 = nums1[i−1] যদি i > 0, নাহলে -∞
        R1 = nums1[i] যদি i < m, নাহলে +∞
        L2 = nums2[j−1] যদি j > 0, নাহলে -∞
        R2 = nums2[j] যদি j < n, নাহলে +∞

        যদি L1 <= R2 এবং L2 <= R1:
            // সঠিক কাটা পেয়েছি
            যদি (m + n) % 2 == 1:   // বিজোড়
                ফেরত দাও max(L1, L2)
            নাহলে:                    // জোড়
                ফেরত দাও (max(L1, L2) + min(R1, R2)) / 2
        নাহলে যদি L1 > R2:
            high = i − 1   // i কমান
        নাহলে:   // L2 > R1
            low = i + 1     // i বাড়ান

    ফেরত দাও 0.0   // ইনপুট সঠিক হলে এখানে আসবে না
 
 */

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };
        }
    }

    public class Solution
    {
        public double MedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return MedianSortedArrays(nums2, nums1);
            }
            int m = nums1.Length;
            int n = nums2.Length;
            int low = 0;
            int high = m;
            int totalLeft = (m + n + 1) / 2;
            while (low <= high)
            {
                int i = (low + high) / 2;
                int j = totalLeft - i;
                int L1 = (i > 0) ? nums1[i - 1] : int.MinValue;
                int R1 = (i < m) ? nums1[i] : int.MaxValue;
                int L2 = (j > 0) ? nums2[j - 1] : int.MinValue;
                int R2 = (j < n) ? nums2[j] : int.MaxValue;
                if (L1 <= R2 && L2 <= R1)
                {
                    if ((m + n) % 2 == 1)
                    {
                        return Math.Max(L1, L2);
                    }
                    else
                    {
                        return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0;
                    }
                }
                else if (L1 > R2)
                {
                    high = i - 1;
                }
                else
                {
                    low = i + 1;
                }
            }
            return 0.0; // This line should never be reached if input is valid
        }
    }
}