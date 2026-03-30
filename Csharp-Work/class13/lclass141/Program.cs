using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lclass141
{
    class Program
    {

        static void Main(string[] args)
        {
            person per = new person();

            per.Name = "Tanjim";
            per.Age = 27;
            per.Haspet = true;


            per.Getting();


            Console.ReadLine();

        }//Main
        public class person
        {
            public String Name;
            public int Age;
            public bool Haspet;

            public void Getting()
            {

                Console.WriteLine("Hi namy is " + Name + "My age is" + Age + "pet" + false);
            }
        }
    }//Class
}//Namespace

