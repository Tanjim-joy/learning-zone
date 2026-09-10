using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_20_Exc
{
    public sealed class Employee : person, iRole
    {
        public Employee() { }
        public Employee(int id,string name, string designations, DateTime Joining_Date):base (name,DoB)
        {
            this.Id = id;
            this.Designations = designations;
            this.joiningdate = Joining_Date;
        }

        public int Id { get; set; }
        public string Designations {get;set;}
        public DateTime joiningdate { get; set; }

        public string[] Role { get; set; }
        public static DateTime DoB { get; }

        public int age()
        {
            return DateTime.Now.Year - this.doB.Year;
        }

        public void AddRoles(string[] roles)
        {
            this.Role = roles;
        }

        

        public void AddRole(string[] designations)
        {
            this.Role= designations;

        }

        public string GetRoles()
        {
            return string.Join(",", Role.ToArray());
        }
    }
}
