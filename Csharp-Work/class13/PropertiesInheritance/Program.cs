using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            derived d = new derived();
            d.x = 10;
            Console.WriteLine(d.x);

            Console.ReadKey();
        }//Main

        public int x
        {
            get
            {
                Console.WriteLine("base get");
                return 10;
            }
            set
            {
                Console.WriteLine(" set");
            }
        }
        class derived : Program { }
        
    }//Class
}
