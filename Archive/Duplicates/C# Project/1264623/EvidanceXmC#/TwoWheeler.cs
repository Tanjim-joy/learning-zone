using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidanceXm
{
    public class TwoWheeler : Vehicle
    {
        public TwoWheeler() { this.Wheels = 2; }
        public TwoWheeler(string Model_no, int make,  int cc, string gearType, string design, VehicleType type) : base (Model_no, make, cc, gearType, design, type)
        {

            this.Wheels = 4;
        }
    }
}
