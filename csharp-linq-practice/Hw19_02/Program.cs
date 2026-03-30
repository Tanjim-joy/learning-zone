using Hw19_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw19_02
{
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
    2. Show only Accessories item
    3. Project data with Name and Price and print them
    4. Group data by type and print each group
    5. Print unique type of products in the list
 *
 */
    class Program
    {
        static void Main(string[] args)
        {
            List<product> products = new List<product>()
            {
                new product{id = 1, Name="Separates", Catagories="Women’s Wear", Price = 9050 },
                new product{id = 2, Name="Swimwear", Catagories="Women’s Wear", Price = 2550 },
                new product{id = 3, Name="Sports      ", Catagories="Men’s Wear", Price = 1750 },
                new product{id = 4, Name="Swimwear", Catagories="Men’s Wear", Price = 8550 },
                new product{id = 5, Name="Eyewears", Catagories="Accessories", Price = 2750 },
                new product{id = 6, Name="Watches    ", Catagories="Accessories", Price = 4750 },
                new product{id = 7, Name="Shoes      ", Catagories="Accessories", Price = 3750 }
            };

            //1.Order data on price and print them

            Console.WriteLine($" Products Name \t\t Price\n===============================");
            products.OrderBy(x => x.Price)
                .ToList().ForEach(p => Console.WriteLine(p/*$" {p.Name}\t\t{p.Price}"*/));
            Console.WriteLine();

            //2. Total Sum
            var t = products.Select(x => x.Price).Sum();
            Console.WriteLine($"TOtal Price \t\t\t\t {t} tk");
            Console.WriteLine();

            //3.Show only Accessories item
            Console.WriteLine($" Products Name \t\t Catagories\n====================================");
            products.Where(w => w.Catagories == "Accessories")
                .Select(a => a).ToList()
                .ForEach(m => Console.WriteLine($" {m.Name}\t\t{m.Catagories}"));
            Console.WriteLine();

            //4. Project data with Name and Price and print them
            Console.WriteLine($" Products Name \t\t Price\n====================================");
            foreach(var n in products)
            {
                Console.WriteLine($" {n.Name}\t\t{n.Price}");
            }
            Console.WriteLine();

            //5. Group data by type and print each group

            products.GroupBy(x => x.Catagories)
                .Select(s => s).ToList()
                .ForEach(m => { Console.WriteLine($" \nCatagories {m.Key}\n=====================\n");
                m.ToList().ForEach(q => Console.WriteLine($"{q.Name}\t\t{q.Price}"));});
            Console.WriteLine();

            //6. Print unique type of products in the list
            products.Select(p => p.Catagories)
                .Distinct()
                .ToList()
                .ForEach(d => Console.WriteLine($"{d}"));
            Console.WriteLine();

            

            Console.ReadLine();

        }//main
    }
}
