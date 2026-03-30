using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You have to create a class for 2 dimentional circle.
 * A circle has a property radius and has ways to calculate area and circumference
 * Create the class to respresent a circle. Provide constructors.
 * */

namespace classworksssss
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle C = new Circle();
            Console.Write("Enter Radius of Cricle");
            C.Radius = double.Parse(Console.ReadLine());

            Circle C1 = new Circle(4.5);
            

            Console.WriteLine($"Area {C.getarea():0.00}, Circumference : { C.GetCircumference():0.00}" );
            Console.WriteLine($"Circumference  {C1.GetCircumference():0.000}, Area {C1.getarea():0.00}");


            Console.ReadLine();
        }//Main

    }//class

}//namespace
