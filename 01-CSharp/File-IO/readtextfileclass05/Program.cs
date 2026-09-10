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
            StreamReader sr = new StreamReader(@"..\..\Program.cs");
            for (string line = sr.ReadLine();line != null;
                line = sr.ReadLine())
            {
                Console.WriteLine($"line")
            }
            sr.Close();
            Console.ReadKey();
        }//Main
    }//class
}//namespec
