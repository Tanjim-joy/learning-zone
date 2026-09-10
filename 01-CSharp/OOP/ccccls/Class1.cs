using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccccls
{
    class Class1
    {
        public void waringgmessage (string Message)
        {
            ConsoleColor old = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
            Console.ForegroundColor = old;
        }

        public void infomessage(string Message)
        {
            ConsoleColor old = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ForegroundColor = old;
        }
        public void Message (string message)
        {
            Console.WriteLine(message);
            
        }

        public bool prime (int x)
        {
            bool prime = true;
            for (int i = 2; i<x/2; i++)
            {
                if (x % i == 0)
                {
                    prime = false;
                    break;
                }
            }//for
            return prime;
        }
    }
}
