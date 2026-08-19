Solution solution = new Solution();
/*int[] nums1 = { 1, 2, 3, 0, 0, 0 };
int[] nums2 = { 2, 5, 6 };
solution.Merge(nums1, 3, nums2, 3);

Console.WriteLine(string.Join(", ", nums1));*/

int[] arr = { 1, 2, 3, 4, 5 };
Console.WriteLine(string.Join(", ", solution.ReverseArray(arr)));

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1; // Pointer for the last element in nums1's initial part
        int j = n - 1;
        int k = m + n - 1; // Pointer for the last position in nums1

        while (j >= 0)
        {
            if (i >= 0 && nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }
    }

    public int[] ReverseArray(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        while(left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
        return arr;
    }

    public bool IsPalindrome(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left < right)
        {
            if (arr[left] != arr[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}