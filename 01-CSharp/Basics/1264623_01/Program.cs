using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1264623_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Swaping a & b");
            int a = 30, b = 10;
            Console.WriteLine($"{a}, {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"{a}, {b}");
            Console.ReadKey();
        }//Main

        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    
    }//Class
}//Namespace
