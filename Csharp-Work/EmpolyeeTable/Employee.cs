using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeTable
{
    public sealed class Employee : Person, IRole
    {
        public Employee() { }
        public Employee(int id, string name, DateTime birthDate, DateTime joinDate, Designation designation) : base(name, birthDate)
        {
            this.Id = id; this.JoiningDate = joinDate; this.Designation = designation;
        }

        public string[] Roles { get; set; }
        
        public int Id { get; set; }
        public DateTime JoiningDate { get; set; }
        public Designation Designation { get; set; }
        

        public void AddRoles(string[] roles)
        {
            this.Roles = roles;
        }

        public override int Age()
        {
            return DateTime.Now.Year - this.Birthday.Year;
        }

        public string RolePlays()
        {
            return string.Join(",", this.Roles);
        }
    }
    
}
