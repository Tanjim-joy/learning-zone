using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loops
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingLoops();

            Console.ReadLine();

        }//main

        static void UsingLoops()
        {
            Console.WriteLine("===========For_Loops=============");

            int Num1 = 0;

            for (int n = 1; n <= 10; n++)
            {
                Console.Write($"{n}\t");
                Num1 += n;
            }

            Console.WriteLine();
            {
                Console.WriteLine($"Series Sum = {Num1}");
            }

            Console.WriteLine("===========while loop=============");
            Console.Write("Enter the Number : ");
            int num = int.Parse(Console.ReadLine()); //take user input
            int i = 1;

            while (i <= 10)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
                i = i + 1;
            }

            Console.WriteLine("===========Do_While Loop==========");
            int num3 = 0;
            do
            {
                num3++;
                Console.WriteLine($"{num3}");
            }
            while (num3 < 10);

            Console.WriteLine("==============ForEach loop================");
            double[] rainFallls = new double[] { 7.33, 9.11, 8.71, 9.73 };
            foreach (double d in rainFallls)
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();
        }
    }//class
}//Namespace
