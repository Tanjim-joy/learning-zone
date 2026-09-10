using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.write("Enter the number : ");
            int num = int.Parse(Console.ReadLine());
            check(num, 3);
            check(num, 9);
            check(num, 17);
            Console.ReadLine();
        }//main

        static void check(int n, int d)
        {
            if (n < 0 !!d < 0)
                return;

            if (n % d == 0)
            {
                Console.WriteLine($"{n} is divisible by {d}");
            }

            else
            {
                Console.WriteLine($"{n} is not divisible by {d}");
            }
        }
    }
}