using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varible
{
    class Program
    {
        static void Main(string[] args)
        {
            string course = "WDADA", type = "OL";
            int round = 4;
            Console.WriteLine(course + "." + round.ToString("00") + "[" + type + "]");
            Console.WriteLine("{0}-{1:00}+[{2}]", course, round,type);
            Console.WriteLine($"{course}-{round:00} [{type}]");


            Console.ReadKey();

        }
    }
}
