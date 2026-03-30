using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace item1variable
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SumAvg(25.3, 10.2, 6.4);
            Console.WriteLine($"sum = {result.Item1} & Avg = {result.Item2}");

            var result1 = submuldiv(11.1,22.2,33.3);
            Console.WriteLine($"subtract = {result1.sub} ** muitiply = {result1.multi} ** divide = {result1.div}");

            var result2 = all(1.1, 2.2, 3.3);
            Console.WriteLine($"sum = {result2.Item1.label}= {result2.Item1.value}**** avg = {result2.Item2.label}== {result2.Item2.value}");

            Console.ReadLine();
        }//Main

        static (double, double) SumAvg(double x, double y, double z)
        {
            return (x = y = z, (x + y + z) / 3);
        }

        static (double sub, double multi, double div) submuldiv(double a, double b, double c)
        {
            return (a - b - c, a * b * c, a / b / c);
        }

        static ((string label, double value), (string label, double value))  all(double x , double y, double z)
        {
            return (("sum", x = y = z), ("avg",( x + y + z) / 3));
        }
    }//Class
}//Namespace
