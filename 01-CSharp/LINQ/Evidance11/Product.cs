using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidance11
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name.PadRight(20, ' ')}\t{Price:0.00}\t{Type}";
        }
    }
}
