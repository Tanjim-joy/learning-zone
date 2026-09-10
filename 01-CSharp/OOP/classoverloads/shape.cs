using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classoverloads
{
    public class shape
    {
        public shape(string name)
        {
            this.shapename = name;
            Console.WriteLine("Shape Created");
        }

        public string shapename { get;  }

        public virtual double GetArea() { return 0.0; }
    }

    public class rectangle : shape
    {
        public rectangle() : base("rectangle")
        {
            Console.WriteLine("rectangle created");
        }

        public double length { get; set; }

        public double width { get; set; }
        public override double GetArea()
        {
            return length*width;
        }
    }
    public class cricle : shape
    {
        public cricle() : base("cricle")
        {
            Console.WriteLine("cricle created");
        }

        public double radius { get; set; }

       
        public override double GetArea()
        {
            return 3.14* radius * radius;
        }
    }
}
