using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorks1
{
    class Program
    {
        static void Main(string[] args)
        {
            demo();

            Console.ReadLine();
        }//Main

        public enum day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public struct Box
        {
            public Box(double l, double w)
            {
                this.L = l; this.W = w;
            }
            public double L { get; set; }
            public double W { get; set; }

        }
        static decimal CalValue(decimal amount, day type)
        {
            switch (type)
            {
                case day.Monday:
                    return 0.0M;
                case day.Tuesday:
                    return amount * 0.4M;
                case day.Wednesday:
                    return amount * 0.5M;
                default:
                    throw new Exception("Invalid Type");
            }
        }

        private static void demo() //
        {
            decimal vat = CalValue(500.00M, day.Wednesday);
            Console.WriteLine(vat);
            Box b = new Box(4.5, 3.5);
            Console.WriteLine($"Area: {b.L * b.W}");
            var obj = new { ID = 1, Name = "Anonymous 1", vale = 50 };
            Console.WriteLine($"ID: {obj.ID} Value: {obj.vale}");
            var items = new[]
            {
                new{Name="Item 1", Price=19.09},
                new{Name="Item 2", Price=20.09},
                new{Name="Item 3", Price=15.09},
                new{Name="Item 4", Price=12.09}
            };
            foreach (var o in items)
            {
                Console.WriteLine($"Name: {o.Name} Price:{o.Price}");
            }
        }


        //Program class
    }
}//namespace
