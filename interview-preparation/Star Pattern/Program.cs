using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Star Pattern 01

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("*");
            }

            Console.WriteLine();

            //Star Pattern 02

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Star Pattern 03

            for (int i = 1; i <= 5; i++)
            {
                for (int j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                //}
            }
            //Star Pattern 04

            Console.WriteLine();

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= 5; i++)
            {
                for (int j = i; j <= 4; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            //Star Pattern 05

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Star Pattern 06

            int count = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    count++;
                    Console.Write($"{count} ");
                }
                Console.WriteLine();
            }

            //Star Pattern 07

            for (int i = 1; i <= 4; i++)
            {
                for (int j = i; j <= 4; j++)
                {
                    count--;
                    Console.Write($"{count} ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine();

            //Star Pattren 08

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 2; j <= i; j++)
                {
                    Console.Write(" ");
                }
                for (int l = i; l <= 5; l++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = 1; i <= 5; i++)
            {
                for (int j = i; j <= 4; j++)
                {
                    Console.Write(" ");
                }
                for (int l = 1; l <= i; l++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            //Star Pattren 09

            for (int i = 1; i <= 5; i++)
            {
                for (int j = i; j <= 4; j++)
                {
                    Console.Write(" ");
                }
                for (int l = 1; l <= 2 * i - 1; l++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            for (int i = 1; i <= 5; i++)
            {
                for (int j = 2; j <= i; j++)
                {
                    Console.Write(" ");
                }
                for (int l = 2 * i - 1; l <= 9; l++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}




