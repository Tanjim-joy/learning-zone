namespace Dictionary_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*// Create a dictionary to store key-value pairs
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            // Add some key-value pairs to the dictionary
            myDictionary.Add("apple", 1);
            myDictionary.Add("banana", 2);
            myDictionary.Add("orange", 3);
            // Access values using keys
            Console.WriteLine($"The value for 'apple' is: {myDictionary["apple"]}");
            Console.WriteLine($"The value for 'banana' is: {myDictionary["banana"]}");
            Console.WriteLine($"The value for 'orange' is: {myDictionary["orange"]}");
            // Check if a key exists in the dictionary
            if (myDictionary.ContainsKey("grape"))
            {
                Console.WriteLine($"The value for 'grape' is: {myDictionary["grape"]}");
            }
            else
            {
                Console.WriteLine("Key 'grape' does not exist in the dictionary.");
            }
            // Iterate through the dictionary
            Console.WriteLine("All key-value pairs in the dictionary:");
            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }*/

            /*  Level -01 Sum of array */
            int[] numbers = { 1, 2, 3, 4, 5,6,7,8,9 };
            int sum = 0;
            foreach (int number in numbers)
            {
                sum+= number;
            }
            Console.WriteLine($"The sum of the array is: {sum}");
            /*  Using Dictionary to count frequency of each number */
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (keyValuePairs.ContainsKey(number))
                {
                    keyValuePairs[number]++;
                }
                else
                {
                    keyValuePairs[number] = 1;
                }
            }
            foreach (var kvp in keyValuePairs)
            {
                Console.WriteLine($"Number: {kvp.Key}, Count: {kvp.Value}");
            }
        }
    }
}
