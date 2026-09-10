using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, fact = 1;
            a =int.Parse(Console.ReadLine());

            for (int i = 1; i <= a; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine($"Factorial of a Number {fact}");

            Console.ReadKey();
        }
    }
}
