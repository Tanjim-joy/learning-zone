Solution Solution = new Solution();
Console.WriteLine(Solution.Convert("PAYPALISHIRING", 3));

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if(numRows == 1 || numRows >= s.Length)
        {
            return s;
        }

        List<string> rows = new List<string>(); // Create a list to hold the rows of the zigzag pattern

        for (int i = 0; i < numRows; i++)
        {
            rows.Add("");
        }

        int currentRow = 0;
        bool goingDown = false;

        foreach(char c in s)
        {
            rows[currentRow] += c;
            if (currentRow == 0 || currentRow == numRows - 1)
            {
                goingDown = !goingDown;
            }
            currentRow += goingDown ? 1 : -1;
        }

        return string.Join("", rows);
    }
}