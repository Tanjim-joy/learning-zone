using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork14
{
    public class person
    {
        public person()
        {
            Console.WriteLine("new line");
            this.Name = "";
            this.Birthday = DateTime.Now;
        }

        public person(string name)
        {
            Console.WriteLine($"creating new baby {Name}");
            this.Name = Name;
            this.birthday = DateTime.Now;

        }
        public string Name { get; set; }
        public DateTime {get; set;}
    public string info()
    {
        return($)
    }
}



