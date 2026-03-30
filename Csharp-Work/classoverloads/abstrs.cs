using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classoverloads
{
    public abstract class  abstrs
    {


        public  abstrs(string name)
        {
            this.abstrsname = name;
            Console.WriteLine("Shape Created");
        }

        public string abstrsname { get; }
        public abstract double Getarea();

        public abstract double getcirumference();
    }

    public class rectangle : abstrs
    {
        public rectangle() : base("rectangle")
        {
            Console.WriteLine("rectangle created");
        }

        public double length { get; set; }

        public double width { get; set; }
        public override double GetArea()
        {
            return length * width;
        }
    }
    public class cricle : abstrs
    {
        public cricle() : base("cricle")
        {
            Console.WriteLine("cricle created");
        }

        public double radius { get; set; }


        public override double Getarea()
        {
            return 3.14 * radius * radius;
        }
    }
}

