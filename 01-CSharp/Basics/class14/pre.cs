using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class14
{
     public class pre
    {
        #region Constructors
        public pre()
        {
            Console.WriteLine("Creating A Baby...");
            this.Name = "";
            this.BirthDay = DateTime.Now;
        }
        public pre(string name)
        {
            Console.WriteLine($"Creating a baby with name {name}");
            this.Name = name;
            this.BirthDay = DateTime.Now;
        }

        #endregion
        #region Props

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        #endregion
        #region Methods
        public string Info()
        {
            return $"{this.Name}\nBorn on {BirthDay:MMM dd, yyyy HH:mm tt}";
        }
        #endregion
    }
}
