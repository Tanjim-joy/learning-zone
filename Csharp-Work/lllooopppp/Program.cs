using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forloo_whileloop
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "loop";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.Write("Enter the Number : ");
            int num = int.Parse(Console.ReadLine());//take user input
            int i = 1;

            while (i <= 10)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
                i = i + 1;
            }

            //write a for loop

            Console.Write("Enter the Another number : ");//take an input num2
            int num2 = int.Parse(Console.ReadLine());


            for (i = 1; i <= 10; i = i + 1)
            {
                Console.WriteLine($"{num2} X {i} = {num2 * i}");

            }

            //nested loop

            Console.Write("Enter the number (1 to 10) : ");
            int num3 = int.Parse(Console.ReadLine());

            for (; num3 <= 10; num3 = num3 + 1)
            {
                for (i = 1; i <= 10; i = i + 1)
                {
                    Console.WriteLine($"{num3} + {i} = {num3 + i}");
                }
            }

            //nested loop
            Console.Write("Enter number (1 to 5) : ");
            int num4 = int.Parse(Console.ReadLine());

            for (; num4 <= 5; num4 = num4 + 1)
            {
                for (int a = 1; a <= 5; a = a + 1)
                {
                    for (i = 1; i <= 5; i = i + 1)
                    {
                        Console.WriteLine($"{num4}\t {a}\t {i}");
                    }
                }
            }

            Console.ReadKey();

        }//main
    }
}