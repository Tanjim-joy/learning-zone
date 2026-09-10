using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readtextfileclass05
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"E:\IsDB\c#\C# LAB\loop\Program.cs");
            int i = 0;
            for (string line = sr.ReadLine(); line != null;
                line = sr.ReadLine())
            {
                Console.WriteLine($"{++i:00}\t{line}");
            }
            sr.Close();


            Console.WriteLine("=============================");
            StreamReader sr1 = new StreamReader(@"E:\IsDB\c#\C# LAB\loop\Program.cs");
            int j = 0;
            string lines = sr1.ReadLine();

            while(lines != null)
            {
                Console.WriteLine($"{++j}\t{lines}");
                lines = sr1.ReadLine();
            }
            sr.Close();

            Console.ReadKey();
        }//Main
    }//class
}//namespec
