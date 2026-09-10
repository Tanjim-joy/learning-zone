using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name : ");
            string name = Console.ReadLine();

            Console.Write("Your Age : ");
            int age = int.Parse(Console.ReadLine());
            value(name,age);

            Console.ReadLine();
        }//main

        static void value(string name, int age)
        {

            age++;
            Console.WriteLine($"Your Name is {name} your age is  {age}");
            
        }
    }//class

}//Namespace
