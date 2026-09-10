    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace take_user_input
{
    class Program
    {
        static void Main(string[] args)
        {
            String name;
            int age;
            decimal yearly_Income;

            Console.Write("Your Name : ");
            name = Console.ReadLine();

            Console.Write("Your Age : ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Your Yearly Income : ");
            yearly_Income = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"{name} Age {age} income/year {yearly_Income:0.00}");

            Console.ReadLine();
        }
    }
}
