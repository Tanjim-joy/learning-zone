using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter The Number to check Palindrome = ");
            int num = int.Parse(Console.ReadLine());
            int result = 0;
            int rem;
            int temp = num;

            while (num != 0)
            {
                rem = num % 10;
                result = result * 10 + rem;
                num = num / 10;
            }
            if (temp == result)
            {
                Console.WriteLine($"{result} is Plaindrome Number");
            }
            else
            {
                Console.WriteLine($"{result} is not Plaindrome Number");
            }

            Console.ReadKey();
        }
    }
}
