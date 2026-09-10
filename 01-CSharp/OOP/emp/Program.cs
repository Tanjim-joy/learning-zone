using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emp
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee emp = new Employee();
            Console.Write("ID : ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Name :");
            emp.Name = Console.ReadLine();

            Console.Write("Brith date : ");
            emp.Birthday = DateTime.Parse(Console.ReadLine());

            Console.Write("Designations : [1-CEO,2-GM,3-AGM, 4-Marketing,85- Excutive]");
            emp.Designation = (designation)int.Parse(Console.ReadLine());
            Console.Write("Joining Date: ");
            emp.Joindate = DateTime.Parse(Console.ReadLine());
            Console.Write("Roles [Sperate by comma]: ");
            string input = Console.ReadLine();
            emp.AddRoles(input.Split(','));
            Console.WriteLine();
            Console.WriteLine("Output");
            Console.WriteLine($"ID {emp.Id}");
            Console.WriteLine($"Name {emp.Name}");
            Console.WriteLine($"Birth Date {emp.Birthday:dd-MM-yyyy}");
            Console.WriteLine($"Joining Date {emp.JoiningDate:dd-MM-yyyy}");
            Console.WriteLine($"Designation {emp.Designation}");
            Console.WriteLine($"Roles: ");
            foreach (var r in emp.Roles)
            {
                Console.WriteLine(r);
            }





                Console.ReadLine();
        }//Main

        public abstract class person
        {
            public person() { }
            public person (string name,DateTime birthday)
            {
                this.Name = name;
                this.Birthday = birthday;
            }

            public string Name  { get; set; }
            public DateTime Birthday { get; set; }
            public abstract int age();
        }

        public sealed class Employee : person, IRole
        {
            public Employee() { }
            public Employee(int id, string name, DateTime birthday, DateTime joindate, Designation designation) : base(name, BirthDate)
            {
                this.Id = id;
                this.Name = name;
                this.Birthday = birthday;
                this.Joindate = joindate;
                this.Designation = designation;
            }

            public int Id { get; set; }
            public DateTime Joindate { get; set; }

            public designation Designation {get;set;}
            public string[] Roles { get; set; }
            public static DateTime BirthDate { get; set; }
            public object JoiningDate { get; internal set; }

            public override int age()
            {
                return DateTime.Now.Year - this.Birthday.Year;
            }
            public void AddRoles(string[] roles)
            {
                this.Roles = roles; 
            }
            public string Roleplayes()
            {
                return string.Join(",",this.Roles);
            }

            public void AddRole(string[] roles)
            {
                throw new NotImplementedException();
            }

            public string RolePlayes()
            {
                throw new NotImplementedException();
            }
        }

        public interface IRole
        {
            void AddRole(string[] roles);
            string RolePlayes();
        }

    }//Class



}//Namespace
