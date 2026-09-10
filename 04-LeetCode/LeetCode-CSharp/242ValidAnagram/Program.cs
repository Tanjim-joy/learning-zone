Solution Solution = new Solution();
string s = "anagram";
string t = "nataram";
Solution s2 = new Solution();
//Console.WriteLine(s2.IsAnagram(s, t));

string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
foreach(var group in s2.GroupAnagrams(strs))
{
    Console.WriteLine(string.Join(", ", group));
}

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
        {
            return false;
        }
        int[] counts = new int[26]; // Assuming only lowercase letters a-z

        for(int i = 0; i < s.Length; i++)
        {
            counts[s[i] - 'a']++;
            counts[t[i] - 'a']--;
        }

        for(int i = 0; i < 26; i++)
        {
            if(counts[i] != 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        var charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
        foreach (char c in t)
        {
            if (!charCount.ContainsKey(c))
            {
                return false;
            }
            charCount[c]--;
            if (charCount[c] < 0)
            {
                return false;
            }
        }
        return true;
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var anagramGroups = new Dictionary<string, List<string>>();
        foreach(var str in strs)
        {
            var charArray = str.ToCharArray(); 
            Array.Sort(charArray); 
            var sortedStr = new string(charArray); 
            if(anagramGroups.ContainsKey(sortedStr))
            {
                anagramGroups[sortedStr].Add(str);
            }
            else
            {
                anagramGroups[sortedStr] = new List<string>();
                anagramGroups[sortedStr].Add(str);
            }
        }
        return anagramGroups.Values.Select(list => (IList<string>)list).ToList();
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }       
    }
    public TreeNode SortedArrayToBST(int[] nums)
    {
        if(nums == null || nums.Length == 0)
        {
            return null;
        }
        return BuildTree(nums, 0, nums.Length - 1);
    }

    private TreeNode BuildTree(int[] nums, int start, int end)
    {
        if(end < start)
        {
            return null;
        }

        int mid = start + (end - start) / 2;
        TreeNode node = new TreeNode(nums[mid]);

        node.left = BuildTree(nums, start, mid - 1);
        node.right = BuildTree(nums, mid + 1, end);

        return node;
    }

}


