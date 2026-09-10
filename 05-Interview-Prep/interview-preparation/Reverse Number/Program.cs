using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Reverse the Number!");           
            Console.WriteLine("Please note that zeros will be ignored while reversing the number.");
            
            Console.Write("Enter Your Number: ");

            int num = int.Parse(Console.ReadLine());
            int result = 0;
            while (num != 0)
            {
                int rem = num % 10;
                result = result * 10 + rem;
                num = num / 10;
            }
            Console.WriteLine("The reversed number is: " + result);

            Console.ReadKey();
        }
    }
}
