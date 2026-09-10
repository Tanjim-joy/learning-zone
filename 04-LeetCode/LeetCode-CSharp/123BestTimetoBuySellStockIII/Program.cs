Solution Solution = new Solution();
int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };
Console.WriteLine(Solution.MaxProfit(prices));


public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int firstBuy = int.MinValue;
        int lastBuy = int.MinValue;

        int firstSell = 0;
        int lastSell = 0;

        foreach(int price in prices)
        {
            firstBuy = Math.Max(firstBuy, -price);
            firstSell = Math.Max(firstSell, firstBuy + price);
            lastBuy = Math.Max(lastBuy, firstSell - price);
            lastSell = Math.Max(lastSell, lastBuy + price);
        }
        return lastSell;
    }
}