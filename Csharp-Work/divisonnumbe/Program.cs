using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace divisonnumbe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("plz Enter the number : ");
            int num =int.Parse (Console.ReadLine());
            int pr,s, d;

            if (num % 2 == 0)
            {
                Console.WriteLine($"{num} is divisor number ");
            }
            else
            {
                Console.WriteLine($"{num} is not divsor number");
            }
            
            pr = num / 2;
            if (num % pr == 0)
            {
                Console.WriteLine($"{num} is not prime number.");
                d = pr + num;
                Console.WriteLine($"if is prim number Summation {pr} + {num} = {d}.");
            }
            else
            {
                Console.WriteLine($"{num} is prime number.");
                d = pr - num;
                Console.WriteLine($"if is prim number subtract {pr} - {num} = {d}.");
            }

            s = num + pr;
            Console.WriteLine($"{num} + {pr} = Total {s}.");

            d = num/2;
            if (d == pr)
            {
                Console.WriteLine($"{num} = {pr}.");
            }
            else
            {
                Console.WriteLine($"{num} =! {pr}");
            }

                Console.ReadLine();
        }
    }
}
