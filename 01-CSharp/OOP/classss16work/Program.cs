using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            workers[] workers = new workers[]
            {
               new workers("W1", 2000.00M, DateTime.Parse("2021-06-03"),DateTime.Parse("2021-06-10")),
               new workers("W2", 1000.00M, DateTime.Parse("2021-06-03"), null),
               new workers {Name="W3", PayRate=1000M, StartDate = DateTime.Parse("2021-06-24")}
            };
            foreach (var wr in workers)
            {
                Console.WriteLine($"{wr.Name} : {wr.Payment()}");
            }

            Console.ReadKey();
        }//main

    }
    public class workers
    {
        public workers() { }
        public workers(string name, decimal payrate, DateTime stardate, DateTime? enddate)
        {
            this.Name = name;
            this.PayRate = payrate;
            this.StartDate = stardate;
            this.EndDate = enddate;
        }
        public string Name { get; set; }//property
        public decimal PayRate { get; set; }//property
        public DateTime StartDate { get; set; }//property
        public DateTime? EndDate { get; set; }//property

        public decimal Payment()
        {
            int days = ((EndDate.HasValue ? EndDate.Value : DateTime.Now) - StartDate).Days + 1;
            return days * PayRate;

            //if (EndDate.HasValue)
            //{
            //    int d = (EndDate.Value - StartDate).Days + 1;
            //    return d * PayRate;
            //}
            //else
            //{
            //    int d = (DateTime.Now - StartDate).Days + 1;
            //    return d * PayRate;

        }
    }//workers

}