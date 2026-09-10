using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userinput
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * take slaes from user claculate commision (7.5%);
             * cheek for input error
             */
            try
            {
                Console.Write("Enter The Sales Amount : ");
                decimal Sales_Amount = decimal.Parse(Console.ReadLine());
                decimal Commisions = Sales_Amount * 7.5M / 100;

                Console.WriteLine($"Your Total Amount {Sales_Amount} & Your Sales Commission IS {Commisions:0.00}");
            }
            catch (Exception EX)
            {
                Console.WriteLine($"ERROR :{EX.Message}");
            }
            finally
            {
                Console.ReadLine();
            }


            
        }//Main
    }//class
}//Namespace
