using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_20_Exc
{
    public abstract class person
    {

        public  person() { }
        public person (string name, DateTime DoB)
        {
            this.Name = name;
            this.doB = DoB;
        }

        public string Name { get; set; }
        public DateTime doB { get; set; }

        
    }
}
