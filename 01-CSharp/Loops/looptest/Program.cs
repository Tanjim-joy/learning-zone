using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace looptest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i <= 5)
            {
                i++;
                Console.Write($"{i} While loop");
            }

            for( i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i} For loop");
            }

            Console.ReadLine();

        }//Main
    }//Class
}//Namespece
