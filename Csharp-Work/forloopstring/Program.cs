using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forloopstring
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3; 
            numbers[3] = 4;
            numbers[4] = 5;
            numbers.SetValue(10,2);

            for(int i =0;i<numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]}");
            }

            Console.WriteLine();
            double[] rainFallls = new double[] { 7.33, 9.11, 8.71, 9.73 };
            foreach (double j in rainFallls)
            {
                Console.WriteLine(j);
            }




            Console.ReadLine();

        }//Main
    }//class
}//namespec
