using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle
{
    public abstract class Vehicle : Car, Pbike
    {
        public Vehicle() { }
        public Vehicle (int Model,DateTime Makeyear, int CC, String type):base(Name,Model,Service_Date)
        {
            this.model = Model;
            this.Year = Makeyear;
            this.CC = CC;
            this.type = type;
        }

        public int model { get; set; }
        public DateTime Year { get; set; }
        public int CC { get; set; }
        public string type { get; set; }

        public override int Getuse()
        {
            return DateTime.Now.Year - this.Year.Year;
        }
    }

    public interface Pbike
    {
        void AddRoles(string[] roles);
        string RolePlays();
    }
}

