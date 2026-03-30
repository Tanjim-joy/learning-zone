using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasAges
{
    class Program
    {
        static void Main(string[] args)
        {
            inputUserDetails();

            Console.ReadLine();
        }//Main

        static void inputUserDetails()
        {
            //take user input user name
            Console.Write("Enter Yoour Name ");
            string name = Console.ReadLine();

            //take user input user dob
            Console.Write("Enter your Date of Brith. ");
            DateTime DOB =DateTime.Parse(Console.ReadLine());

            int AgeinYear = Age(DOB);
            
            Console.WriteLine($"{name} your is age is {}")
        }
        static int Age (DateTime dateofbrith)
        {
            int year = (DateTime.Now - dateofbrith).Days / 365;
            return year;
        }
    }

}
