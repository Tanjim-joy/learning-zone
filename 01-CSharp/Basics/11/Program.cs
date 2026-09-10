using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1264623
{
    class Program
    {

        //global variable
        static DateTime dateExam;
        static void Main(string[] args)
        {
            Console.WriteLine();
            PrePostFix();

            UsingVariables();

            Console.WriteLine();
            UsingDecision();

            Console.ReadLine();
        }//Main

        static void UsingDecision()
        {
            Console.WriteLine("Branching");
            Console.WriteLine("if..else..");
            Random r = new Random();
            int n1 = r.Next(1, 15);
            int n2 = r.Next(1, 12);
            Console.Write($"{n1}+{n2}=? ");
            int ans = int.Parse(Console.ReadLine());
            if (ans == n1 + n2)
            {
                Console.WriteLine("Thats right");
            }
            else
            {
                Console.WriteLine("Oops,It's wrong.");
            }

            Console.WriteLine("switch case");
            Console.Write($"{n1}-{n2} =? ");
            ans = int.Parse(Console.ReadLine());
            switch (ans == n1 - n2)
            {
                case true:
                    Console.WriteLine("Thats right");
                    break;
                case false:
                    Console.WriteLine("Oops, wrong.");
                    break;
                default:
                    Console.WriteLine("Result error");
                    break;
            }
        }

        static void UsingVariables()
        {
            Console.WriteLine("Global Variable");
            dateExam = new DateTime(2021, 6, 27); //assignment
            Console.WriteLine($"Exam Date: {dateExam:yyyy-MM-dd}");
            Console.WriteLine("Local Variable");
            string course = "ASP.NET";
            float pi = 3.14F;
            decimal wage = 9000.75M;
            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"PI: {pi}");
            Console.WriteLine($"Wage: {wage}");
        }

        static void PrePostFix()
        {
            Console.WriteLine("Pre and Post fix");
            int x = 10;
            Console.WriteLine($"x={x}");
            int m = ++x;//Prefix

            Console.WriteLine($"m={m}");
            Console.WriteLine($"x={x}");
            int n = x++;

            Console.WriteLine($"n={n}");
            Console.WriteLine($"x={x}");
        }

        
    }//Class
}//Namespace
