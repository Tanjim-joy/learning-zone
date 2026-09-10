using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loop
{
    class Program
    {
        static int n1, n2;
        static void Main(string[] args)
        {
            Askquestion();
            int ans = int.Parse(Console.ReadLine());
            if (ans == n1 + n2)
            {
                Console.WriteLine("Your Are Welcome");
            }
            else
            {
                Console.WriteLine("Try again Next Time");
            }
            Console.ReadKey();
        }
        static void Askquestion()
        {
            Random r = new Random();
            n1 = r.Next(1, 10);
            n2 = r.Next(1, 10);
            Console.Write($"{n1} + {n2} = ? ");
        }
    }
}
