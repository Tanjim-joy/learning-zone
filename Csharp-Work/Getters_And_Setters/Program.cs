using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getters_And_Setters
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie avenger = new Movie("The Avenger", "Joss Whedon","pc");
            Movie sherk = new Movie("Sherk", "Adam Adsmson", "PG");
            sherk.Rating = "GR";
            Console.WriteLine(sherk.Rating);

            Console.WriteLine(avenger.Rating);
            Console.ReadLine();
        }
    }
}
