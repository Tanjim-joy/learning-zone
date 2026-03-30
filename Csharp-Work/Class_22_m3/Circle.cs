using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_22_m3
{
    public class Circle
    {
        public Circle() { }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; set; }
        public double Area() => Math.PI * Radius * Radius;
        ////Oparetor Overloding
        public static Circle operator +(Circle x, Circle y)
        {
            return new Circle(x.Radius + y.Radius);
        }
        public static Circle operator -(Circle x, Circle y)
        {
            return new Circle(Math.Abs(x.Radius - y.Radius));
        }
        public static Circle operator ++(Circle x)
        {
            return new Circle(x.Radius + 1);
        }
        public static Circle operator --(Circle x)
        {
            return new Circle(x.Radius - 1);
        }

        public static bool operator >(Circle x, Circle y)
        {
            return x.Radius > y.Radius;
        }
        public static bool operator <(Circle x, Circle y)
        {
            return x.Radius < y.Radius;
        }
    }

}
