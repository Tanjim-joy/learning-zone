using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_ioop
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            Console.Write("place Enter age : ");
            age = int.Parse(Console.ReadLine());

            if (age >= 18)
            {
                Console.WriteLine("You Are Welcome");
            }
            else
            {
                Console.WriteLine("visited kids website");
            }

            Console.ReadKey();



        }//main
    }//prigram
}//namespace
