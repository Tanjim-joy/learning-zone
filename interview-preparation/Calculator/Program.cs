using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Frist  Number : ");
            int n1 = int.Parse(Console.ReadLine());

            Console.Write("Using Symbol + - * / % : ");
            string operand = Console.ReadLine();

            Console.Write("Enter the Second Number : ");
            int n2 = int.Parse(Console.ReadLine());          
            float ans;

            switch(operand)
            {
                case "+":
                    ans = n1 + n2;
                    break;

                case "-":
                    ans = n1 - n2;
                    break;

                case "*":
                    ans = n1 * n2;
                    break;

                case "/":
                    ans = n1 / n2;
                    break;

                case "%":
                    ans = n1 % n2;
                    break;

                default:
                    ans = 0;
                    break;
            }
            Console.WriteLine($"{n1} {operand} {n2} = {ans} ");

            Console.ReadKey();
        }
    }
}
