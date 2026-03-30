using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000022222
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write($"Enter The Number : ");
            int x = int.Parse(Console.ReadLine());

            Console.Write($"Number of y : ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"Number of x {x}");

            Console.WriteLine($"Number of y {y}");


            opertorout(ref y);
            Console.WriteLine($"Number y--:{y}");

            opertor(ref x);
            Console.WriteLine($"Number x++:{x}");

            Console.WriteLine($"{x} + {y} = {x+y}");
            
            Console.ReadLine();
        }//Main

        static void opertorout(ref int n)
        {
            n -= 4;
        }

        static void opertor(ref int m)
        {
            m += 5;
        }

        
    }//Class
}//Namespace
