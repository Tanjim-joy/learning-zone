using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorFunction
{
    class Book
    {
        public string title;
        public string autor;
        public decimal price;


        public Book(string aTitle,string aAutor, int aPrice)
        {
            this.title = aTitle;
            this.autor = aAutor;
            this.price = aPrice;

            Console.WriteLine($"A book Tirle is {title} written by {autor} price is {250}");
        }
    }
}
