using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainee
{
    public class Traninee:person,Isubject
    {
        public Traninee()
        {
            this.Subjects = new List<string>();
        }
        public Traninee(int id,string name, string address, DateTime DoB,Course course):base(name, address, DoB)
        {
            this.Id = id;
            this.Course = Course;
            this.Subjects = new List<string>();
        }
        public int Id { get; set; }
        public Course Course { get; set; }
        public List<string> Subjects { get; set; }
        

        public void AddSubjects(string[] subjects)
        {
            this.Subjects.AddRange(subjects);
        }

        public override int age()
        {
            return DateTime.Now.Year - Dateofbirth.Year;
        }

        public string Getsubjects()
        {
            return string.Join(",", Subjects.ToArray());
        }
    }
}
