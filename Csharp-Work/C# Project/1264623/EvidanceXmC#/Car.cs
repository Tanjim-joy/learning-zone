using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidanceXm
{
    public sealed class Car : FourWheeler, IExteriorFeature
    {
        private string[] Feature { get; set; }
        public void AddFeature(string[] feature)
        {
            this.Feature = feature;
        }

        public string GetFeature()
        {
            return string.Join(",", this.Feature);
        }
        public override string ToString()
        {
            return base.ToString()
                + "\n" +
                $"Feature: {GetFeature()}";
        }
    }
}
