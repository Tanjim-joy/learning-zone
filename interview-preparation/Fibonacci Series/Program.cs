using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = 0;
            b = 1;
            Console.WriteLine($"Fibonacci Series start {a} {b}");

            for (int i = 0; i <= 10; i++)
            {
                c = a + b;
                //Console.WriteLine(c);
                a = b;
                b = c;
                Console.WriteLine($" {a} + {b} = {a+b}");
                
            }


            Console.ReadKey();
        }
    }
}
