using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            person p1 = new.person();
            p1.Name = "Moon";
            person p2 = new person("karim");
            Console.WriteLine(p1.info);
            Console.WriteLine(p2.info);

            Console.ReadLine();
        }//Main
    }//class
}//Namespace
