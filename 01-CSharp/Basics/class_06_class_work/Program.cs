using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_06_class_work
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int m = int.Parse("56"), n = 0;
                int r = m / n;
                throw new Exception("A fatal error occurred. ");
            }
            catch(FormatException fex)
            {
                Console.WriteLine("input error " + fex.Message);
            }
            catch(DivideByZeroException dex)
            {
                Console.WriteLine("Illegal operations: "+dex.Message);

            }catch(Exception ex )
            {
                Console.WriteLine("unkonwn error:" + ex.Message);
            }

            Console.ReadKey();
        }//Main
    }//Class
}//Namespace
