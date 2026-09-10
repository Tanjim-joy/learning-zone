using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace taksjk
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 10; i<=30; i += 10)
            {
                Console.WriteLine($"Passing {i}");
                callprint(i );
            }

            Console.ReadLine();
        }//Main
        static void callprint(int x)
        {
            Task.Run(() => PrintTimeConsuming (x));
        }
        static void PrintTimeConsuming (int n)
        {
            Console.WriteLine($"Got {n}");
            for(int i = 1; i<= n; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                Task.Delay(250).Wait();
            }
        }
    }//progrram

}//Namespace
