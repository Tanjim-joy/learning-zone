using Hw19_ClassWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw19_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Books> books = new List<Books>
            {
                new Books {id = 1, Name ="Spoking English", Gener = "Learn Languge", CoverPrice = 450.52},
                new Books {id = 2, Name ="Thakumar Jhuli", Gener = "story", CoverPrice = 50.20},
                new Books {id = 3, Name ="Learn Basic Computer", Gener = "Technical", CoverPrice = 150.52},
                new Books {id = 4, Name ="Spoking Arabick", Gener = "Learn Languge", CoverPrice = 980.52},
                new Books {id = 5, Name ="Eran Money", Gener = "Learn & Eran", CoverPrice = 750.52},
            };
            //Show Book Name and Covery Price For Books Covery Price > 500;
            Console.WriteLine($"Name \t\t CoverPrice");
            var n = (from b in books
            where b.CoverPrice > 500
            select new { b.Name, b.CoverPrice }).ToList();

            foreach (var i in n)
            {
                Console.WriteLine($"{i.Name}\t {i.CoverPrice}");
            }
            Console.WriteLine("==============================");
            Console.WriteLine($"Name \t\t Gener \t\t CoverPrice");
            books.Where(g => g.CoverPrice > 200)
                .Select(f => new { f.Name, f.Gener, f.CoverPrice }).ToList()
                .ForEach(a=> Console.WriteLine($"{a.Name}\t {a.Gener}\t {a.CoverPrice}"));
            //Find Out Genres 
            Console.WriteLine("==============================");
            Console.WriteLine("Query No 02");
            

            (from b in books
             select b.Gener).Distinct().ToList().ForEach(j=> Console.Write($"{j}\t"));
            Console.WriteLine();
            Console.WriteLine("==============================");
            var w = (from e in books
             select e.Name).Count();
            Console.WriteLine($"Total Number Of Books: {w}");

            Console.WriteLine("==============================");
            Console.WriteLine("Query No 03");
            Console.WriteLine();
            //Show the Book Name Cover Price & Discount Price 

            books
             .Select(o => new { o.Name, o.CoverPrice, DiscountPrice = o.CoverPrice * .8 }).ToList()
             .ForEach(y => Console.WriteLine($"{y.Name}\t {y.CoverPrice}\t {y.DiscountPrice}"));

            Console.WriteLine("==============================");
            Console.WriteLine("Query No 04");
            Console.WriteLine();

            var qu = (from r in books
                      group r by r.Gener into r
                      select r);
            foreach (var q in qu)
            {
                Console.WriteLine(q.Key);
            }
            Console.WriteLine("==============================");
            Console.WriteLine("Query No 04");
            Console.WriteLine();

            var qu1 = (from r in books
                       group r by r.Gener into r
                       select r);
            foreach (var q in qu1)
            {
                Console.WriteLine($"=======================================================\n\t\tGroup By Gener: {q.Key}\n=======================================================");
                foreach (var r in q)
                {
                    Console.WriteLine($"{r.Name}\t\t {r.CoverPrice}");
                }
            }
            var qu2 = (from q in books
                       group q by q.CoverPrice < 200 into r1
                       select r1);
            foreach (var t in qu2)
            {
                Console.WriteLine($"=======================================================\n\t\tCover Price : {t.Key}\n=======================================================");
                foreach (var q in t)
                {
                    Console.WriteLine($"{q.Name}\t\t{q.CoverPrice}");
                }
            }

            //books.GroupBy(b => b.CoverPrice >= 150)
            //    .Select(wq => wq).ToList()
            //    .ForEach(a => { Console.WriteLine($"\t{a.Key}");
            //        a.ToList().ForEach(q=> { Console.WriteLine($"{q.Name}\t\t {q.CoverPrice}"); });
            //    });
            Console.ReadKey();
        }
    }
}
