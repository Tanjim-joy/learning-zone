using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Gen
{
    class Animal
    {

        public Animal() { }

        public Animal(string name, int age, AnimalType type, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
            this.Sex = sex;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public Gender Sex { get; set; }
    }
}
