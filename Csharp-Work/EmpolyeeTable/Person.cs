using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeTable
{
    public abstract class Person
    {
        public Person() { }
        public Person(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public abstract int Age();
    }
}
