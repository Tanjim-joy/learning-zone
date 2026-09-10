using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        
            static void Main(string[] args)
            {
                Task
                    .Run<long>(() => Addup(5))
                    .ContinueWith(t => Console.WriteLine($"Go result {t.Result} @ {DateTime.Now}"));
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} working...");
                }
            Console.ReadLine();

            }

           
        
    }//Program
    static long Addup(int n)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Started Processing ...@"{ DateTime.Now);
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} adds {i}");
                sum += i;
                Thread.Sleep(500);
            }
            return sum;
        }
    }
}






