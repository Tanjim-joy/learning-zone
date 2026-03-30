using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchC
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4, j = 0;
            

            try
            {

                Console.Write("Enter the Number : ");
                int num1 =int.Parse(Console.ReadLine());

                Console.Write("Enter the operstor : ");
                Char operations = Convert.ToChar(Console.ReadLine());

                Console.Write("Enter 2nd number : ");
                int num2 = int.Parse(Console.ReadLine());

                if (operations == '+')
                {
                    Console.WriteLine($"Sum is {num1} + {num2} = {num1 + num2}");
                }

                else if (operations == '-')
                {
                    Console.WriteLine($"Sub is {num1} - {num2} = {num1 - num2}");

                }

                else if (operations == '/') 
                {
                    Console.WriteLine($"div is {num1} / {num2} = {num1 / num2}");
                }
                else if (operations == '*')
                        {
                    Console.WriteLine($"multiply is {num1} * {num2} = {num1 * num2} ");
                }
                else
                {
                    Console.WriteLine($"Wrong operator");
                }

                int r = n / j;
                Console.WriteLine($"{r}");
                throw new Exception(" new ex error");
                


            }
            catch(FormatException fex)
            {
                Console.WriteLine("Input Error: "+ fex.Message);
            }
            catch(DivideByZeroException dex)
            {
                Console.WriteLine("Illegal operations : "+ dex.Message);
            }
            catch(Exception ex)
            {
                    Console.WriteLine("unkonwn Error :" + ex.Message);
            }

                Console.ReadLine();
        }//Main
    }//Class
}//NameSpace
