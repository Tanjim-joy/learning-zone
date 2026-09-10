Solution Solution = new Solution();
string s = "anagram";
string t = "nagaram";
Solution solution = new Solution();

Console.WriteLine(solution.IsAnagram(s, t));


public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
        {
            return false;
        }

        var charCount = new Dictionary<char, int>();
        foreach(var c in s)
        {
            charCount[c] = charCount.GetValueOrDefault(c, 0) + 1; // Increment the count for the character c in the dictionary
        }

        foreach(var c in t)
        {
            if(!charCount.ContainsKey(c))
            {
                return false;
            }

            charCount[c]--;
            if(charCount[c] == 0)
            {
                charCount.Remove(c);
            }
        }

        return charCount.Count == 0;
    }
   
}
