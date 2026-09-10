using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidanceXm
{
    public class FourWheeler : Vehicle
    {
        public FourWheeler() { this.Wheels = 4; }
        public FourWheeler(string Model_no, int make, int seat, int cc, string gearType, int Door, string design, VehicleType type) : base (Model_no, make, seat,cc, gearType, Door, design, type)
        {

            this.Wheels = 4;
        }

        
    }
}
