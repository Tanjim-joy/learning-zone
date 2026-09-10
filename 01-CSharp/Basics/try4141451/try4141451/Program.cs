using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try4141451
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter The Sales Amount : ");
            try
            {
                decimal sales = decimal.Parse(Console.ReadLine());
                decimal Comm0ssion = sales * 7.5M / 100;

                Console.WriteLine($"Commission : {Comm0ssion:0.000}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }

            Console.ReadKey();
        }//main
    }//program
}//namespaec
