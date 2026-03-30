using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class7._2
{
    public class primeclass
    {
        public void waring(string message)
        {
            ConsoleColor color = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(message);
            Console.ForegroundColor = color;
        }

        public void info(string message)
        {
            ConsoleColor color = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        public void info1(string message)
        {
            ConsoleColor color = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
        public void Message(string message)
        {
            Console.Write(message);

        }

        public bool prime(int x)
        {
            bool prime = true;
            for (int i = 2; i<x/2; i++)
            {
                if (x % 2 == 0)
                {
                    prime = false;
                    break;
                }
            }//for loop.
            return prime;
        }
    }
}

