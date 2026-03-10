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
            
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3,4 };

            Console.WriteLine("Median: " + solution.FindMedianSortedArrays(nums1, nums2));         
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length) // Always binary search on the smaller array
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            int m = nums1.Length;
            int n = nums2.Length;
            int low = 0;
            int high = m;
            int totalLeft = (m + n + 1) / 2;

            while (low <= high)
            {
                int i = (low + high) / 2;           // nums1 থেকে কতগুলি বামে নেব
                int j = totalLeft - i;              // nums2 থেকে কতগুলি বামে নেব

                int L1 = (i > 0) ? nums1[i - 1] : int.MinValue; // nums1 এর শেষ বাম এলিমেন্ট
                int R1 = (i < m) ? nums1[i] : int.MaxValue;     // nums1 এর প্রথম ডান এলিমেন্ট
                int L2 = (j > 0) ? nums2[j - 1] : int.MinValue; // nums2 এর শেষ বাম এলিমেন্ট
                int R2 = (j < n) ? nums2[j] : int.MaxValue;     // nums2 এর প্রথম ডান এলিমেন্ট

                if (L1 <= R2 && L2 <= R1) //    সঠিক পার্টিশন পেয়েছি
                {
                    if ((m + n) % 2 == 1) // // যদি মোট এলিমেন্ট বিজোড় হয়
                    {
                        return Math.Max(L1, L2); // বিজোড় হলে বাম পাশের সর্বোচ্চ এলিমেন্টই মধ্যমা হবে
                    }
                    else
                    {
                        return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0; // জোড় হলে বাম পাশের সর্বোচ্চ এবং ডান পাশের সর্বনিম্নের গড় হবে
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
            return 0.0; 
        }
    }
}


/*
    nums1 = [1, 3]
    nums2 = [2]

    মার্জ করলে: [1, 2, 3]
    মিডিয়ান = 2

    কোড যেভাবে কাজ করে:
    i = 1 (nums1 থেকে 1টা)
    j = 1 (nums2 থেকে 1টা)

    L1 = 1, R1 = 3
    L2 = 2, R2 = int.MaxValue

    L1(1) <= R2(Max) ✓
    L2(2) <= R1(3) ✓

    মোট এলিমেন্ট = 3 (বিজোড়)
    return Math.Max(1, 2) = 2

*/