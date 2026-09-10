using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainee
{
    public abstract class person
    {
        public person() { }
        public person (string name, string address,DateTime DoB)
        {
            this.name = name;
            this.address = address;
            this.Dateofbirth = DoB;
        }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime Dateofbirth { get; set; }
        public abstract int age();

    }
}
