using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forloops1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter The Number : ");
            int num1 = int.Parse(Console.ReadLine());
            int i = 1;

            for( i= 1; i <=10; i++)
            {
                Console.WriteLine($"{num1} X {i} = {num1 *  i}");

            }

            Console.WriteLine("=======Nested For Loop=================");
            Console.Write("Enter number <= 5 : ");
            int num2 = int.Parse(Console.ReadLine());



            for (; num2 <= 5; num2 = num2 + 1)
                
            {
                for (i = 0; i <= 5; ++i)
                    
                {
                    for (int a = 1; a <= 5; a++)
                    {
                        Console.WriteLine($"{num2}\t {i}\t {a}");
                        if (num2 >= 6) break;
                    }
                }
            }

            Console.ReadKey();


        }//main
    }//class
}//namespace
