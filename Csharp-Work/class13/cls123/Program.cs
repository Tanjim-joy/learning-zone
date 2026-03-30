using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cls123
{
    class Program
    {
        static void Main(string[] args)
        {
            captcha x = new captcha();
            
            Console.Write(x.create());
            int ans = int.Parse(Console.ReadLine());
            Console.WriteLine(x.cheek(ans) ? "that's right" : "wrong answer!" );


            Console.Write(x.create());
            ans = int.Parse(Console.ReadLine());
            Console.WriteLine(x.cheek(ans) ? "that's right" : "wrong answer!");
            

            Console.ReadLine();
        }//Main
    }//class

    public class captcha
    {
        private int n1, n2;
        public string create()
        {
            Random q = new Random();
            n1 = q.Next(1, 5);
            this.n2 = q.Next(5, 10);
            return $"{n1} + {n2} = ?";
            
        }
        public bool cheek(int anser)
        {
            return anser == n1 + n2;
        }
    }

}//namespace
