
Solution solution = new Solution();
int[] price = { 7, 6, 4, 3, 1 };
int profit = solution.MaxProfit(price);
Console.WriteLine(profit);

public class Solution
{
    public int MaxProfit(int[] price)
    {
        int minPrice = int.MaxValue; // Initialize minPrice to the largest possible integer value
        int maxPrice = 0; // Initialize maxPrice to the smallest possible integer value

        foreach (int priceItem in price)
        {
            if (priceItem < minPrice)
            {
                minPrice = priceItem; // Update minPrice if a new minimum is found
            }
            else if (priceItem - minPrice > maxPrice)
            {
                maxPrice = priceItem - minPrice; // Update maxPrice if a new maximum profit is found
            }
        }
        return maxPrice;
    }
}