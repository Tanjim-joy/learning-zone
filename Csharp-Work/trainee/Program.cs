using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainee
{
    class Program
    {
        static void Main(string[] args)
        {
            Traninee tran = new Traninee();
            Console.Write("Id : ");
            tran.Id = int.Parse(Console.ReadLine());
            Console.Write("Name : ");
            tran.name = Console.ReadLine();
            Console.Write("Address : ");
            tran.address = Console.ReadLine();
            Console.Write("Date of birth : ");
            tran.Dateofbirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Course [1-WebApplications,2-Programing,3-Database,4-Datastructure,5-Network : ");
            tran.Course = (Course)int.Parse(Console.ReadLine());
            Console.Write("Subjects : ");
            string input = Console.ReadLine();

            tran.AddSubjects(input.Split(','));
            Console.WriteLine();
            Console.WriteLine("------------show output-----------");
            Console.WriteLine($"Id : {tran.Id} \n Name : {tran.name}\n Address: {tran.address}\n Birth Date :{tran.Dateofbirth:dd-MM-yyyy}");
            Console.WriteLine($"Course: {tran.Course}");
            Console.WriteLine($"Subjects: {tran.Getsubjects()}");
            



            Console.ReadLine();
        }//Main
    }//Class program
}//NameSapce 
