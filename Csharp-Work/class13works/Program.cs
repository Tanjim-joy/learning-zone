using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class13works
{
    class Program
    {
        static void Main(string[] args)
        {
            box b = new box();
            b.Length = 9.99;
            b.Width = 5;

            Console.WriteLine($"Area : {b.Area()}");

            Console.ReadLine();
        }//Main
    }//Program
    public class box
    {
        private double _Length;
        private double _Width;

        public double Length
        {
            get { return _Length; }
            set
            {
                if (value <= 0) throw new Exception("Invalid length");
            }
        }


        public double Width
        {
            get { return _Width; }
            set
            {
                if (value <= 0) throw new Exception("Invalid width");
            }
        }

        public double Area()
        {
            return Length * Width;
        }
    }
}//Namespace
