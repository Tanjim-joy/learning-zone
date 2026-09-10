using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> {
                new Product {ProductID = 1, Name = "LL Road Frame - Red, 44", ProductNumber = "FR-R38R-44", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 44, Weight = 1052.33, ProductCategoryID = 18, ProductModelID = 9
  },
                new Product {ProductID = 2, Name = "LL Road Frame - Red, 48", ProductNumber = "FR-R38R-48", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 48, Weight = 1070.47, ProductCategoryID = 18, ProductModelID = 9 },
                new Product { ProductID = 3, Name = "LL Road Frame - Red, 52", ProductNumber = "FR-R38R-52", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 52, Weight = 1088.62, ProductCategoryID = 18, ProductModelID = 9 },
                new Product { ProductID = 4, Name = "LL Road Frame - Red, 58", ProductNumber = "FR-R38R-58", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 58, Weight = 1115.83, ProductCategoryID = 18, ProductModelID = 9
 },
                new Product { ProductID = 5, Name = "LL Road Frame - Red, 60", ProductNumber = "FR-R38R-60", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 60, Weight = 1124.9, ProductCategoryID = 18, ProductModelID = 9
 },
                new Product { ProductID = 6, Name = "LL Road Frame - Red, 62", ProductNumber = "FR-R38R-62", Color = "Red", StandardCost = 187.1571, ListPrice = 337.22, Size = 62, Weight = 1133.98, ProductCategoryID = 18, ProductModelID = 9
 },
                new Product { ProductID = 7, Name = "ML Road Frame - Red, 44", ProductNumber = "FR-R72R-44", Color = "Red", StandardCost = 352.1394, ListPrice = 594.83, Size = 44, Weight = 1006.97, ProductCategoryID = 18, ProductModelID = 16
 },
                
            };
            List<ProductCategory> categories = new List<ProductCategory> {
                new ProductCategory {ProductCategoryID = 1, Name = "Bikes" },
                new ProductCategory { ProductCategoryID = 2, Name = "Components"  },
                new ProductCategory { ProductCategoryID = 3, Name = "Clothing"  },
                new ProductCategory { ProductCategoryID = 4, Name = "Accessories"  },
                new ProductCategory { ProductCategoryID = 5, Name = "Mountain Bikes"},
                new ProductCategory { ProductCategoryID = 6, Name = "Road Bikes"  },
                new ProductCategory { ProductCategoryID = 7, Name = "Touring Bikes" },
               
            };
            List<ProductModel> models = new List<ProductModel> {
                new ProductModel {ProductModelID = 1, Name = "Classic Vest"  },
                new ProductModel {ProductModelID = 2, Name = "Cycling Cap"  },
                new ProductModel {ProductModelID = 3, Name = "Full-Finger Gloves"  },
                new ProductModel {ProductModelID = 4, Name = "Half-Finger Gloves"  },
                new ProductModel {ProductModelID = 5, Name = "HL Mountain Frame" },
                new ProductModel {ProductModelID = 6, Name = "HL Road Frame"  },
                new ProductModel {ProductModelID = 7, Name = "HL Touring Frame" },
                

            };

            //1 Group products by model
            products
                .GroupBy(p => p.ProductModelID)
                .Select(gr => new
                {
                    gr.Key,
                    Products = gr
                })
                .ToList()
                .ForEach(g =>
                {
                    var model = models.First(m => m.ProductModelID == g.Key).Name;
                    Console.WriteLine($"model Id: {g.Key} Name {model}");
                    foreach (var p in g.Products)
                    {
                        Console.WriteLine($"\t{p.Name}, {p.ListPrice}, {p.Color}");
                    }
                });
            
            //3 Inner join
            Console.WriteLine();
            var q = from p in products
                    join m in models on p.ProductModelID equals m.ProductModelID
                    join c in categories on p.ProductCategoryID equals c.ProductCategoryID
                    select new { Category = c.Name, Model = m.Name, p.Name, p.ListPrice, p.Color };

            foreach (var x in q)
            {
                Console.WriteLine($"{x.Name} Category:{x.Category} Model: {x.Model}, Price: {x.ListPrice}");
            }
            //4 Left outer join
            var q1 = from c in categories
                     join p in products on c.ProductCategoryID equals p.ProductCategoryID into cp
                     from np in cp.DefaultIfEmpty()
                     select new { Category = c.Name, Name = np == null ? "-" : np.Name, np?.ListPrice, np?.Color };
            Console.WriteLine();
            foreach (var x in q1)
            {
                Console.WriteLine($"{x.Category}:: Product Name: {x.Name} Price: {x.ListPrice}, Colr: {x.Color}");
            }
            Console.ReadLine();
        }
    }
}
 