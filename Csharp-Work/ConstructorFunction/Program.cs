using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("tanjim's", "Joy", 2);

            Book book2 = new Book("tanjim","tanjim", 25);


            Console.WriteLine(book1.title);
            Console.WriteLine(book2.price);


            Console.ReadLine();
        }
    }
}
