using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classworksssss
{
    public class Circle
    {
        public Circle() { }
        public Circle (double radius)
        {
            this.Radius = radius;
        }//constructors
        private double _radius;
        public double Radius
        {
            get => this._radius;
            set
            {
                if (value > 0) this._radius = value;
                else throw new Exception("invalid radius");
            }
        }//pro.

        public double getarea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
