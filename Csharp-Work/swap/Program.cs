using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;
            Console.WriteLine($"a={a}, b={b}");

            swap(ref a, b);
            Console.WriteLine($"a={a}, b={b}");


            Console.ReadLine();
        }//Main

        static void swap(ref int a, int b)
        {
            int t = a;
            a = b;
            b = a;
        }
    }//Class
}//Namespace
