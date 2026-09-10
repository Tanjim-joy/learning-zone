using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw19_02.Models
{
    public class product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Catagories { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{id}\t {Name}\t {Catagories}\t {Price}";
        }
    }
}
