using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle
{
     public abstract class Car
    {
        public Car() { }

        public Car(string name, string Type, string Model,DateTime Service_Date)
        {
            this.Name = name;
            this.Type = Type;
            this.Model = Model;
            this.Service_Date = Service_Date;
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public DateTime Service_Date { get; set; }

    }
}
