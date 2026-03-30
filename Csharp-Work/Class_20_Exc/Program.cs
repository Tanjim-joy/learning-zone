using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_20_Exc
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Emp = new Employee();
            Console.Write("Enter Id :");
            Emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Your Name : ");
            Emp.Name = Console.ReadLine();

            Console.Write("Enter date - month - year : ");
            Emp.joiningdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Role [separate by na,e]");
            string input = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("output");
            Console.WriteLine($"Id {Emp.Id}\n Name : {Emp.Name}\n Birth Day : {Emp.doB: dd:mm:yyyy} \n Joining Date : {Emp.joiningdate: dd:mm:yyyy}" );
            Console.WriteLine($"Designations {Emp.Designations}");
            Console.WriteLine($"Role : {Emp.Role}");



            Console.ReadLine();
        }//Main 
    }//Class
    
}//NameSpace
