using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {

            
            decimal pr1 = clacprice(4.70M);
            decimal pr2 = clacprice(.97m,discount : 5);
            decimal pr3 = clacprice(qty: 25, unitprice: 25.26M);

            Console.WriteLine(pr1 + pr2 + pr3);
            pr1 = clacprice(25.26M , 1 , 1.5M);
            pr2 = clacprice(25.2M, 2);
            pr3 = clacprice(discount: 70, unitprice: 1000M);

            Console.WriteLine(pr1 + pr2 + pr3);
            Console.ReadLine();
        }//Main

        static decimal clacprice(decimal unitprice, int qty )
        {
            return unitprice * qty;
        }

        static decimal clacprice(decimal unitprice, int qty = 1,decimal discount =0)
        {
            return unitprice * qty - discount;
        }
    }//class
}//namespace
