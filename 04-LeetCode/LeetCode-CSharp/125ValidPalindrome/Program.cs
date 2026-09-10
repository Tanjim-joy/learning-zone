using System.Text.RegularExpressions;

Solution Solution = new Solution();
string s = "A man, a plan, a canal: Panama";
Solution s2 = new Solution();
Console.WriteLine(s2.IsPalindrome(s));


public class Solution
{
    public bool IsPalindrome(string s)
    {       
        string cleaned = new string(s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray());

        string reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;

        /*string removed = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
        int left = 0;
        int right = removed.Length - 1;

        while(left < right)
        {
            if (removed[left] != removed[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;*/
    }
}