using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidanceXm
{
    class Vehicle
    {
        public Vehicle() { }

        public Vehicle(string model_no, int make, int cc, string gearType, string design, VehicleType type)
        {
            Model_no = model_no;
            this.make = make;
            this.cc = cc;
            this.gearType = gearType;
            this.design = design;
            Type = type;
        }

        public Vehicle (string Model_no,int make,int seat, int cc, string gearType,int Door,string design, VehicleType type)
        {
            this.Model_no = Model_no;
            this.make = make;
            this.seat = seat;
            this.cc = cc;
            this.gearType = gearType;
            this.Door = Door;
            this.design = design;
            this.Type = type;
        }
        public string Model_no { get; set; }
        public int make { get; set; }
        public int seat { get; set; }
        public int cc { get; set; }
        public string gearType { get; set; }
        public int Door { get; set; }
        public string design { get; set; }
        public VehicleType Type { get; set; }

        protected int Wheels { get; set; }
        public override string ToString()
            {
            return $"ModeL: {this.Model_no}\nSeat: {this.make}\nMake: {this.seat}\n Door: {this.Door}\n Design :{this.design}\nCC: {cc}\nType: {this.Type}\n" +
                $"Gear Type: {gearType}";
        }


    }
}
