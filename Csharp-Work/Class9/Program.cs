using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Number = new int[5];
            Number[0] = 7;
            Number[1] = 5;
            Number[2] = 9;
            Number[3] = 11;
            Number[4] = 3;

            for (int i = 0; i < Number.Length; i++)
            {
                Console.WriteLine(Number[i]);
            }
            Console.WriteLine();

            double[] rainfails = new double[] { 7.33, 9.11, 8.71, 9.73 };
            foreach (double d in rainfails)
            {
                Console.WriteLine(d);
            }

            Console.ReadKey();
        }//Main
    }//Class
}//Namespce
