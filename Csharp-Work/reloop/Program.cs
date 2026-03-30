using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reloop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * sum of the even numbers
             */

            Console.WriteLine("1+2+3+......+10 = ");
            Console.WriteLine();

            int sumeven = 0, sumodd = 0;
            for(int i = 1; i <= 10; i = i + 1)
            {
                if (i % 2 == 0) sumeven += i;
                else sumodd += i;
            }

            Console.WriteLine($"1+2+......+10={sumeven}");
            Console.WriteLine($"1+.,,,,,+9={sumeven}");

            Console.ReadKey();

        }//main
    }//program
}//namespace
