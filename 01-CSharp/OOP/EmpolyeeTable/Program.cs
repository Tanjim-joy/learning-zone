using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.Write("ID");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Name : ");
            emp.Name = Console.ReadLine();
            Console.Write("Bith of Date :");
            emp.Birthday = DateTime.Parse(Console.ReadLine());
            Console.Write("Designation: [1-GM, 2-AGM, 3-SM, 4-Manager, 5-Executive]");
            emp.Designation = (Designation)int.Parse(Console.ReadLine());
            Console.Write("Joining Date: ");
            emp.JoiningDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Roles [Separate by comma]: ");
            string input = Console.ReadLine();
            emp.AddRoles(input.Split(','));
            Console.WriteLine();
            Console.WriteLine("Output");
            Console.WriteLine($"ID {emp.Id}");
            Console.WriteLine($"Name {emp.Name}");
            Console.WriteLine($"Birth Date {emp.Birthday:dd-MM-yyyy}");
            Console.WriteLine($"Joining Date {emp.JoiningDate:dd-MM-yyyy}");
            Console.WriteLine($"Designation {emp.Designation}");
            Console.WriteLine($" {emp.Age}");
            Console.WriteLine($"Roles: ");
            foreach (var r in emp.Roles)
            {
                Console.WriteLine(r);
            }




            Console.ReadLine();
        }//Main
    }//Program
}//namespace
