    `using System;

namespace forl
{
    class Program
    {
        static void Main(string[] args)
        { 
            for (int i=1; i <= 5; i = i+1)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();

            for (int i = 1; i <= 5; i += 2)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();

            for (int i = 1; i <= 10; ++i)
            {
                if (i % 2 == 0)
                    Console.Write($"odd {i}\t  ");
                else
                    Console.Write($"even {i}\t");
            }
            Console.WriteLine();

            int sum = 0;
            for(int i = 1; i<=10; i=i+1)
            {
               sum += i;
            }

            /* Console.WriteLine($"1+2+3.........+10={sum}");
              Console.WriteLine();

              int sumodd = 0, sumeven = 0;
              for(i=1;i <=10; ++i)
              {
                  if (i % 2 == 0) sumeven +=i;
                  else sumodd +=i;
              }

              Console.WriteLine($"1+.,,,,,+10={sumeven}");
              Console.WriteLine($"1+.,,,,,+9={sumeven}");*/

            /*int result = 1;
            for( int n = 1; n <= 10; n++)
            {
                result *= n;
            }
            Console.WriteLine($"!*2*3*.....*10 = {result}");

            result = 0;
            for(int n = 1; n<=10; n++)
            {
                result += n * n;
            }
            Console.WriteLine($"1^2+ 2^2+....={result}");

            /* for (int i = 1; i <= 10; i++) ;
             Console.Write($"{i}\t");
             if( i % 3 == 0)
             {
                 Console.WriteLine();
             }*/

            Console.Title = "Factorial";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            Console.Write("Enter a number between 1 and 10 :");
            int n = int.Parse(Console.ReadLine());

            if(n <1 || n > 10)
                {
                Console.WriteLine("input out of range");
                Console.ReadKey();
                return;

            }
            long fact = Factorial(n);
            Console.WriteLine($"{n} != {fact}");
            fact = factrialv2(n);

            Console.ReadKey();
        }//main

        private static long Factorial(int n)
        {
            long f = 1;
            for (int i = n; i > 0; i--)
            {
                f *= 1;
            }
            return f;
        }

        private static long factrialv2(int n)
        {
            if (n == 1) return 1;

            return n * factrialv2(n - 1);
        }
    }

}
