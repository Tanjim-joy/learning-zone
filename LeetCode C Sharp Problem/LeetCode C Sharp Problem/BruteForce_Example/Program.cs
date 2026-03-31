using System;

class Program
{
    static void Main()
    {
        string target = "tangimul";
        Console.WriteLine($"Target string: {target}");

        Console.WriteLine($"\n Starting Brute Force Search...\n");

        // Brute Force Search: Generate all possible combinations of characters
        char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        bool found = false; 
        int attemptCount = 0;

        for (int length = 8; length <=8 && !found; length++) // Limit the length of combinations to 3 for demonstration        
        {
            Console.WriteLine($"Trying passwords of length {length}...");
            GenerateCombinations(chars, "", length, target, ref found, ref attemptCount);
        }
        Console.WriteLine($"\nTotal attempts: {attemptCount}");
    }

    private static void GenerateCombinations(char[] chars, string v, int length, string target, ref bool found, ref int attemptCount)
    {
        if (found)
        {
            return;
        }

        if (v.Length == length)
        {
            attemptCount++;
            Console.WriteLine($"Trying: {v}");

            if (v == target)
            {
                Console.WriteLine($"Password found: {v}");
                found = true;
            }
            return;
        }
        foreach (char c in chars)
        {
            if (found)
            {
                return; // Stop generating further combinations if found
            }
            GenerateCombinations(chars, v + c, length, target, ref found, ref attemptCount);
        }
    }
}