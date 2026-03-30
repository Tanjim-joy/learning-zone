using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class14
{
    class Program
    {
        static void Main(string[] args)
        {
            pre p1 = new pre();
            p1.Name = "tanjim";
            pre p2 = new pre("joy");
            Console.Write(p1.Info());
            Console.Write(p2.Info());


            Console.ReadLine();
        }//Main
    }//Class
}//Namespace
