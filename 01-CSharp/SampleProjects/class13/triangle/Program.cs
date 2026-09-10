using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            triangles tri = new triangles();
            tri.Base = 1.25;
            tri.heght = 7.55;
            Console.WriteLine($"Height :{tri.trianglehight() * 0.5}");



            Console.ReadLine();
        }//Main

        /*
         When the base and height of a triangle are given.
         */
        public class triangles
        {
            private double hgt;
            private double ba;

            public double heght
            {
                get { return hgt; }
                set
                {
                    if (value <= 0) throw new Exception("Invalid heght");
                    hgt = value;
                }

            }
            public double Base
            {
                get { return ba; }
                set
                {
                    if (value <= 0) throw new Exception("Invalid heght");
                    ba = value;
                }
            }

            public double trianglehight()
            {
                return (ba * hgt);
            }

        }
        

         

    }//class
}//namespace
