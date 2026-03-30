using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class13
{
    class Program
    {
        static void Main(string[] args)
        {
            Box b = new Box();
            b.Length = 9.99;
            b.Width = 5;
            Console.WriteLine($"Area: {b.Area()}");

            Console.ReadLine();
        }//Main
    }//Program
    public class Box
    {
        private double _length;
        private double _width;
        public double Length
        {
            get { return _length; }
            set
            {
                if (value <= 0) throw new Exception("Invalid length");
                _length = value;
            }
        }
        public double Width
        {
            get { return _width; }
            set
            {
                if (value <= 0) throw new Exception("Invalid width");
                _width = value;
            }
        }
        public double Area()
        {
            return Length * Width;
        }

    }//Box

}//Namespace
