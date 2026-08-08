Solution solution = new Solution();

// Test case 1: [0,0,1] -> [1,0,0]
int[] test1 = { 0, 0, 1 };
/*solution.MoveZeroes(test1);
Console.WriteLine($"Test 1: [{string.Join(", ", test1)}]");*/

// Test case 2: [0]
/*int[] test2 = { 0 };
solution.MoveZeroes(test2);
Console.WriteLine($"Test 2: [{string.Join(", ", test2)}]");*/

// Test case 3: [1, 2, 3]
int[] test3 = { 1, 2, 3 };
/*solution.MoveZeroes(test3);
Console.WriteLine($"Test 3: [{string.Join(", ", test3)}]");*/

// Test case 4: [0, 1, 0, 3, 12]
int[] test4 = { 0, 1, 0, 3, 12 };
solution.leraningarray(test4);
/*
Console.WriteLine($"Test 4: [{string.Join(", ", test4)}]");*/

public class Solution 
{
    public void leraningarray(int[] nums)
    {
        // search elements array 3

        foreach (int x in nums)
        {
            if (x == 3)
            {                                
                int swap = Array.IndexOf(nums, x);
                nums[swap] = nums[swap - 1];
                nums[swap - 1] = swap;
            }
            Console.WriteLine($"Current array: [{string.Join(", ", nums)}]");

        }

    }

    /*public void MoveZeroes(int[] nums)
    {
        if(nums == null || nums.Length == 0) return;

        int lastNonZeroFoundAt = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0)
            {
                nums[lastNonZeroFoundAt++] = nums[i];
            }
        }

        while(lastNonZeroFoundAt < nums.Length)
        {
            nums[lastNonZeroFoundAt++] = 0;
        }
    }*/

}