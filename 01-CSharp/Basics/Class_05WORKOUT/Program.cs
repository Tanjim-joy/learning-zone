using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_05WORKOUT
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ram = new Random();
            int num1 = ram.Next(1, 15);
            int num2 = ram.Next(1, 10);

            Console.Write($"{num1} + {num2} ? = ");
            int ans = int.Parse(Console.ReadLine());

            if (ans == num1 + num2)
            {
                Console.WriteLine("weldone you are welcome");
            }
            else
            {
                Console.WriteLine("try next time");
            }

            Console.ReadLine();


        }//main
    }//class
}//namespace
