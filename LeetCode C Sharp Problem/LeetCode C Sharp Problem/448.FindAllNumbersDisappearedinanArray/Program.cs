Solution solution = new Solution();
//int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };
//Console.WriteLine(string.Join(", ", solution.FindDisappearedNumbers(nums)));

int[] nums = { 3, 2, 3 };
Console.WriteLine(solution.MajorityElement(nums));


public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        int [] result = new int[nums.Length];
        List<int> disappeared = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            result[nums[i] - 1] = 1;
        }

        /*foreach (int num in result)
        {
            if (num == 0)
            {
                disappeared.Add(result.IndexOf(num) + 1);  // This line will not work as expected because IndexOf will always return the first occurrence of 0, which is not what we want. We need to use a different approach to find the missing numbers.
            }
        }*/

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == 0)
            {
                disappeared.Add(i + 1);
            }
        }

        /*foreach (int num in nums)
        {
            result[num - 1] = 1;
        }
        

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == 0)
            {
                disappeared.Add(i + 1);
            }
        }

        return disappeared;*/

        return disappeared;
    }

    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int candidate = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += (num == candidate) ? 1 : -1; // If the current number is the candidate, increment count; otherwise, decrement count.
        }

        return candidate;
    }
}