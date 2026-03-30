using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Id, Name, Type, Price (guess data type form the sample data)
    You have to store the following product instances in a collection
    Id	Name		Type		Price
    ====== ================ =============== ===========
    1	Beans		Food		280.00
    2	Soya Protien	Suppliment	310.00
    3	Canola Oil	Food		530.00
    4	Cod Liver	Suppliment	870.00
    5	Olive Oil	Food		330.00
    Then peroform the following queries
    1. Order data on price and print them
    2. Show only food item
    3. Project data with Name and Price and print them
    4. Group data by type and print each group
    5. Print unique type of products in the list
 *
 */

namespace Evidance11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product{ Id=1,  Name="Beans",Type="Food", Price=280.00 },
                new Product{ Id=2,  Name="Soya Protien",Type="Suppliment", Price=310.00 },
                new Product{ Id=3,  Name="Beans",Type="Food", Price=280.00 },
                new Product{ Id=4,  Name="Canola Oil",Type="Food", Price=530.00 },
                new Product{ Id=5,  Name="Cod Liver",Type="Suppliment", Price=280.00 },
                new Product{ Id=5,  Name="Olive Oil",Type="Food", Price=330.00 }
            };

            Console.WriteLine("1. Order data on price and print them");
            products
                .OrderBy(p => p.Price)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x}"));
            Console.WriteLine();

            Console.WriteLine("2. Show only food item");
            products
                .OrderBy(p => p.Type == "Suppliment")
                .ToList()
                .ForEach(p => Console.WriteLine($"Type {p}"));

            Console.WriteLine("3. Project data with Name and Price and print them");
            products
                .Select(p => new { p.Name, p.Price })
                .ToList()
                .ForEach(m => Console.WriteLine($"{m.Name.PadRight(30, ' ')}\t{m.Price}"));

            Console.WriteLine("4. Group data by type and print each group");
            Console.WriteLine("4");
            products
                .GroupBy(p => p.Type)
                .ToList()
                .ForEach(gr =>
                {
                    Console.WriteLine(gr.Key);
                    gr
                    .ToList()
                    .ForEach(g => Console.WriteLine($"\t{g}"));
                });
            Console.WriteLine();
            products
                .Select(p => p.Type)
                .Distinct()
                .ToList()
                .ForEach(t => Console.WriteLine(t));



            Console.ReadLine();
        }//Main

    }//Class

}//NameSpce
