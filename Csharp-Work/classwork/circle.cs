using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classwork
{
    public class circle
    {

        public circle() { }
        public circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get => radius;
                set 
            {
                if (value > 0) this.radius = Radius;
                else throw new Exception("Invalid Radius");
            } }
        private double radius;
    }
}
