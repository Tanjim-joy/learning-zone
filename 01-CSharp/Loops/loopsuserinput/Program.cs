using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loopsuserinput
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = new string[3];
            for (int i = 0; i<colors.Length; i++)
            {
                Console.Write($"Favorite color #{i + 1} : ");
                colors[i] = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Favorite colors ");

            string FavColor = string.Join("--",colors);
            Console.WriteLine(FavColor);



            Console.ReadLine();
        }//Main
    }//Class
}//Namespace 
