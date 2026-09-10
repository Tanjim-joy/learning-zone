using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1264623_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            Console.WriteLine(x);
            Increase(ref x);
            Console.WriteLine(x);
            int y;
            //Console.WriteLine(y);
            IncreaseOut(out y);
            Console.WriteLine(y);

            Console.ReadKey();
        }

        static void IncreaseOut(out int y)
        {
            y = 10;
            y++;
        }

        static void Increase(ref int x)
        {
            x += 5;
        }
    }
}
