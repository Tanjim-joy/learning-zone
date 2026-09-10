using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClassssssss
{
    class Program
    {
        static void Main(string[] args)
        {
            myclass mc = new myclass();
            mc.Setm(10);
            int xval = mc.Gety();

            Console.WriteLine(xval);

            Console.ReadLine();
        }//main

        public class myclass
        {
            private int mx;
            public void Setm(int i)
            {
                mx = 10;
            }
            public int Gety()
            {
                return mx;
            }
        }
        

    }//class



}//namespace
