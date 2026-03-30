using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classoverloads
{
    class Program
    {
        static void Main(string[] args)
        {
            rectangle r = new rectangle { length = 5, width = 3.54 };
            print(r);

            cricle c = new cricle { radius = 5.5 };
            print(c);
            Console.ReadLine();
        }//Main

        static void print (shape s)
        {
            Console.WriteLine(s.shapename);
            Console.WriteLine($"Area : {s.GetArea()}");
        }
    }//class
}//Namespace
