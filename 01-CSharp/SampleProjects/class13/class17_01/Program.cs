using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class17_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Tonage = new List<double> { 21.2, 22.3, 18.1, 33.1, 29.1 };
            Tonage.Sort();
            Tonage.Reverse();
            foreach (var n in Tonage)
            {
                Console.WriteLine($"{n}");
            }
            Console.WriteLine();

            List<MobileDevice> Top5Mobile = new List<MobileDevice>
            {
                new MobileDevice {Model = "Samsung 21 Ultra", Price = 78000.00M, UserRatings = 4.7F},
                new MobileDevice {Model = "Iphone 11", Price = 98000.00M, UserRatings = 4.3F},
                new MobileDevice {Model = "Redmi Note 10x", Price = 33000.00M, UserRatings = 4.4F},
                new MobileDevice {Model = "Nokia 11", Price = 55000.00M, UserRatings = 4.2F},
                new MobileDevice {Model = "One Plus Pro", Price = 63500.00M, UserRatings = 4.4F }
            };

            Top5Mobile.Sort((x, y) => x.UserRatings.CompareTo(y.UserRatings)); //Lamda 

            Top5Mobile.Reverse();

            foreach (var m in Top5Mobile)
            {
                Console.WriteLine($"{m.Model} {m.Price} Rating {m.UserRatings}");
            }


            Console.ReadLine();

        }//Main

    }//Class
    public class MobileDevice
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public float UserRatings { get; set; }

    } //MobileDevice Class

}//NameSpace