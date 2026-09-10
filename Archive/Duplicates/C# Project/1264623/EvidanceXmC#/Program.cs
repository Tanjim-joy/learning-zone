using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidanceXm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car input");
            Car c = new Car();
            Console.Write("Model: ");
            c.Model_no = Console.ReadLine();
            Console.Write("Make: ");
            c.make = int.Parse(Console.ReadLine());
            Console.Write("CC: ");
            c.cc = int.Parse(Console.ReadLine());
            Console.Write("Gear Type: ");
            c.gearType = Console.ReadLine();
            Console.Write("Number Of Door :");
            c.Door =int.Parse( Console.ReadLine());
            Console.Write("Number Of seat : ");
            c.seat = int.Parse(Console.ReadLine());

            Console.Write("Type: [NormalCar,RacingCar, FamilyCar]");
            c.Type = (VehicleType)Enum.Parse(typeof(VehicleType), Console.ReadLine());

            Console.Write("Faeture: ");
            string input = Console.ReadLine();
            c.AddFeature(input.Split(','));
            Console.WriteLine("Car input");
            Console.WriteLine();
            Bike b = new Bike();
            Console.Write("Model: ");
            b.Model_no = Console.ReadLine();
            Console.Write("Make: ");
            b.make = int.Parse(Console.ReadLine());
            Console.Write("CC: ");
            b.cc = int.Parse(Console.ReadLine());
            Console.Write("Gear Type: ");
            b.gearType = Console.ReadLine();
            Console.Write("Type: [NormalCar,RacingCar, FamilyCar]");
            b.Type = (VehicleType)Enum.Parse(typeof(VehicleType), Console.ReadLine());


            Console.Write("Faeture: ");
            string input1 = Console.ReadLine();
            b.AddFeature(input1.Split(','));
            Console.WriteLine();
            Console.WriteLine(c);
            Console.WriteLine();
            Console.WriteLine(b);



            Console.ReadLine();
        }//Main
    }//Class
}//Namespace
