using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace readstream
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\program.cs");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            Console.ReadKey();
        }//main
    }//program
}//namespace
