using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccccls
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class122 = new Class1();
            class122.Message("Enter A numbers : ");

            try
            {
                int a = int.Parse(Console.ReadLine());
                bool isprime = class122.prime(a);
                if (isprime)
                {
                    class122.infomessage($"{a} is prime ");
                }
                else
                {
                    class122.infomessage($"{a} is not prime");
                }

            }
            catch(Exception ex)
            {
                class122.waringgmessage($"Error :{ex.Message}");
            }
            finally
            {
                class122.Message("Hit <Enter> to exit");
                Console.ReadLine();
            }

            Console.ReadLine();
        }//Main 
    }//Class
}//Namespace
