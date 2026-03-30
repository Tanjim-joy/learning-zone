using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testtttttskills
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine($"{n}");

            incress(ref n);
            Console.WriteLine($"{n}");

            inscressout(ref n);
            Console.WriteLine($"{n}");

            Console.ReadLine();
        }//main

        static void inscressout(ref int y)
        {
            y -=5;
        }

        static void incress(ref int x)
        {
            x += 1;
        }
    }//class
}//Namespace
