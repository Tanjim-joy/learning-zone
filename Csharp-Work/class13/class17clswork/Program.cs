using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class17clswork
{
        class Program
        {
            static void Main(string[] args)
            {
                int[] primes = Getprime(10, 70);
                foreach (int n in primes)
                {
                    Console.WriteLine(n);
                }
                Console.ReadKey();
            }//main

            static bool isprime(int i)
        {
            bool prime = true;
            for (int j = 2; j < i/2; j++)
            {
                if (i % j == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }
        static int[] Getprime(int l,int u)
        {
            List<int> primeNums = new List<int>();
            for (int i=l; i<u; i++)
            {
                if (isprime(l))
                {
                    primeNums.Add(i);
                }
            }
            return primeNums.ToArray();
        }
    }
}
