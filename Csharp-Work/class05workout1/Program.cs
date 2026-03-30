using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class05workout1
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal price1 = CalcPrice(4.70M, 23);
            decimal price2 = CalcPrice(4.10M, qty: 5);
            decimal price3 = CalcPrice(qty: 20, unitprice: 4.50M);
            Console.WriteLine(price1 + price2 + price3);

            price1 = CalcPrice(.98M);
            price2 = CalcPrice(.98M, discount: 0);
            price3 = CalcPrice(unitprice: 24.98M, discount: 74M, qty: 30);
            Console.WriteLine(price1 + price2 + price3);
            Console.ReadKey();
        }//main
        static decimal CalcPrice(decimal unitprice, int qty)
        {
            return unitprice * qty;
        }
        static decimal CalcPrice(decimal unitprice, int qty = 1, decimal discount = 0)
        {
            return unitprice * qty - discount;
        }
    }
    
}
