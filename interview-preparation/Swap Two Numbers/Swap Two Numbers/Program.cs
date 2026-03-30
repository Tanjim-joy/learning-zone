using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //using three variable
            int a, b, temp;
             a = 5;
             b = 10;
            Console.WriteLine($" After Swaping a = {a} & b = {b}");

            temp = a;
            a = b;
            b = temp;
            Console.WriteLine($" Before Swaping a = {a} & b = {b}");

            //using two variable

            int x, y;
            x = 10;
            y = 100;
            Console.WriteLine($" After Swaping a = {x} & b = {y}");

            x = x + y; // 10 + 100 = 110
            y = x - y; // 110 - 100 = 10
            x = x - y; // 110 - 10 = 100

            Console.WriteLine($" Before Swaping a = {x} & b = {y}");

            Console.ReadKey();
        }
    }
}
