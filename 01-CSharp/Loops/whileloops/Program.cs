using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whileloops
{
    class Program
    {
        static void Main(string[] args)
        {
            print();
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void print()
        {
            int i = 1;
            while (i <= 10) 
            {
                Console.Write($"{i}\t");
                   i  = i + 1;
            }
        }
    }
}
