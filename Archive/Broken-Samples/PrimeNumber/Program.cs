using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, a = 0, b = 0;
            Console.Write("Enter the Number to check Prime: ");
            num = int.Parse(Console.ReadLine());

            a = num / 2;

            for (int i = 2; i < a; i++)
            {
                if(num % i == 0)
                {
                    Console.WriteLine($"{num} is not Prime");
                }
                b = 1;

                break;
            }

            if (b == 2)
            Console.Write("Number is Prime.");

            Console.ReadLine();
        }
    }
}
