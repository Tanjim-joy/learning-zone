using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwforloops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Number 1 = ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the Number 2 = ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Enter (+, -, *, /) =");
            string op = Console.ReadLine();

            if(op == "+")
            {
                Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            }
            else if (op == "-")
            {
                Console.WriteLine($"{num1} - {num2} {num1 + num2}");
            }
            else if (op == "*")
            {
                Console.WriteLine($"{num1} X {num2} {num1 * num2}");
            }
            else if (op == "/")
            {
                Console.WriteLine($"{num1} / {num2} {num1 / num2}");
            }
            else
            {
                Console.WriteLine("Invalid Operations");
            }

            //using switch case;

            Console.Write("Using Case loop");

            switch (op)
            {
                case "+":
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                    break;
                case "-":
                    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                    break;
                case "*":
                    Console.WriteLine($"{num1} X {num2} = {num1 * num2}");
                    break;
                case "/":
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                    break;
                default:
                    Console.WriteLine($"Not Found INvalid operations");
                    break;


            }

            //lowewr case upper case
            Console.Write("Lower to upper case (ch) : ");
            string ch = Console.ReadLine();
            /*
            if (ch >= 'a' && ch <= 'z')
            {
                Console.WriteLine($"{ch} is lower case");
            }
            else
            {
                Console.WriteLine($"{ch} is upper case");
            }
            */
            string UpperCase = ch.ToUpper();
            string lowercase = ch.ToLower();

            Console.WriteLine($"{ch} to Upper = {UpperCase}");
            Console.WriteLine($"{ch} to lowercase = {lowercase}");



            Console.ReadKey();
        }//main
    }
}
