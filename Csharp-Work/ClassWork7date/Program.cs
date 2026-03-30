using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassWork7date
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Detective";
            Thread t1 = new Thread(count);
            Thread t2 = new Thread(count);
            
            Thread t3 = new Thread(C);
            

            t1.Name = "sherlock holmes";
            t2.Name = "byomkesh bakshi";
            t3.Name = "james bond";


            t1.Start();
            t1.Join();
            t2.Start();
            t2.Join();
            t3.Start();



            for (int i =1; i<=5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} count: {i}");
                Thread.Sleep(250);
            }

            

            Console.ReadLine();
        }//Main

        static void C()
        {
            for (int i = 1; i<= 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} count: {i}");
                Thread.Sleep(250);
            }
        }

        static void count()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} count:{i}");
                Thread.Sleep(100);
            }
        }
    }//class
 
}//NameSpace
