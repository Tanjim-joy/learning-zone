using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vari
{
    class Program
    {

        //Global Variable
        static DateTime admissondate;

        static void Main(string[] args)
        {
            
            Console.WriteLine();
            usingvariable();
            Console.WriteLine();
            prepostfix();
            Console.WriteLine();
            decison();
            Console.ReadLine();
        }//Main

        static void usingvariable()
        {
            Console.WriteLine("Golbal Variable");
            admissondate = new DateTime(2021,12, 19); //assignment
            Console.WriteLine($"Admisson Date :{admissondate:yyyy-MMMM-dd}");

            Console.WriteLine("Local Variblae");
            string subject = "C#";
            Console.WriteLine($"The Subject is :{subject}");
            int subcode = 409;
            Console.WriteLine($"Subject Code :{subject + subcode}");

        }

        static void prepostfix()
        {
            Console.WriteLine("pre fix");
            int x = 10;
            Console.WriteLine($"x {x}");
            int n = ++x;//prefix
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"x = {x}");
            int m = x++;//postfix
            Console.WriteLine($"m = {m}");
            Console.WriteLine($"x = {x}");

            Console.WriteLine("post fix");
            int i = 100;
            Console.WriteLine($"i {i}");
            int j =i--;
            Console.WriteLine($"j = {j}");
            Console.WriteLine($"i = {i}");
            int l = --i;
            Console.WriteLine($"l = {l}");
            Console.WriteLine($"i = {i}");
        }


        static void decison()
        {
            Console.WriteLine("Branching");
            Console.WriteLine("if.......else");

            Random ran = new Random();
            int n1 = ran.Next(10, 20);
            int n2 = ran.Next(1, 10);

            Console.Write($"{n1}+ {n2} = ?");
            int sum = int.Parse(Console.ReadLine());

            if (sum == n1 + n2)
            {
                Console.WriteLine("You Are welcome ");
            }
            else
            {
                Console.WriteLine("Plz go back");
            }

            Console.WriteLine("Switch Case");
            switch (sum == n1 + n2)
            {
                case  true:
                    Console.WriteLine("You Are welcome (use switch case)");
                    break;

                case false:
                    Console.WriteLine("Plz go back");
                    break;

                default:

                    Console.WriteLine("Somethings wrong");
                    break;
            }
            
                
        }


    }//class
}//namespace
