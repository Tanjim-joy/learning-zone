using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_22_m3
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            Circle c2 = new Circle();
            Circle bigOne = c1 + c2;
            Circle SmallOne = c1 + c2;

            Console.WriteLine($"c1 + c2 ={bigOne.Radius}");
            Console.WriteLine($"c1 + c2 = {SmallOne.Radius}");
            Console.WriteLine($"C1 > C2");
            c2++;
            --c1;

            Console.WriteLine(c1.Radius);
            Console.WriteLine(c2.Radius);
            Console.ReadLine();

        }
    }
}
