using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            primeclass t1 = new primeclass();
            t1.Message ("enter a number : ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                bool isPrime = t1.prime(n);
                if (isPrime)
                {
                    t1.info($"{n} is prime");
                }
                else
                {
                    t1.info1($"{n} is not prime");
                }
            }
            catch (Exception ex)
            {
                t1.waring($"Error: {ex.Message}");
            }
            finally
            {
                t1.Message("Hit <Enter> to exit");
                Console.ReadLine();
            }



        }//Main
    }//Class
}//Namespace
