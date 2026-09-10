using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 153;
            int rem, cube;
            int result = 0;
            int temp = num;
            temp = num;

            while (num != 0)
            {
                rem = num % 10;
                cube = rem * rem * rem;
                result = cube + result;
                num = num / 10;
            }     

            if (temp ==result)
            {
                Console.WriteLine($"{result} is Armstrong Number ");
            }
            else
            {
                Console.WriteLine($"{result} is't Armstrong Number ");
            }
            Console.ReadKey();
        }
    }
}
