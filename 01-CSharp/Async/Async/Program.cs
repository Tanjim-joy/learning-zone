using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 9, 5, 7, 5, 8 };
            for (var i=0; i<numbers.Length; i++)
            {
                callFact(numbers[i], $"{numbers[i]} !=");
            }
            Console.WriteLine("Waiting ............");
            Console.ReadLine();
        }
        private static async void callFact(int x, string label)
        {
            long f = await FactorialAsync(x);
            Console.WriteLine($"{label}{f}");
        }
        private static async Task<long> FactorialAsync(int n)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} started factorial ${n}");
            long fact = 1;
             Task.Run(() =>
            {
                for (var i = 1; i <= n; i++)
                {
                    fact *= i;
                    Task.Delay(250).Wait();
                }

            }
            ).Wait();
            return fact;
        }
    }
}
