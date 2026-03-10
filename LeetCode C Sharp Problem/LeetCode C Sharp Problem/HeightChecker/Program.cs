namespace HeightChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            
            /*int[] heights = { 1, 1, 4, 2, 1, 3 };
            Console.WriteLine("Height Checker: " + solution.HeightChecker(heights)); */    
            
            string name = "alex";
            string typed = "aaleex";
            Console.WriteLine("Is Long Pressed Name: " + solution.IsLongPressedName(name, typed));
        }
    }

    public class Solution
    {
        public int HeightChecker(int[] heights)
        {
            /*int[] expected = (int[])heights.Clone();
            Array.Sort(expected);
            int count = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != expected[i])
                {
                    count++;
                }
            }
            return count;*/

            int[] expected = (int[])heights.Clone(); 
            Array.Sort(expected); 

            return heights.Where((h, i) => h != expected[i]).Count(); // Count the number of positions where heights differ from expected
        }

        public bool IsLongPressedName(string name, string typed)
        {
            int i = 0, j = 0;
            while (j < typed.Length)
            {
                if(i < name.Length && name[i] == typed[j]) // If characters match, move both pointers
                {
                    i++;
                    j++;
                }
                else if(j > 0 && typed[j] == typed[j - 1]) // If current character in typed matches previous character, it's a long press, move j
                { 
                    j++;
                }
                else
                {
                    return false;
                }
            }
            return i == name.Length; // Ensure all characters in name were matched
        }
    }
}