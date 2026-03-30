using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class19_quary
{
    class Program
    {
        static void Main(string[] args)
        {
            void product(object sender, EventArgs e)
            {
                List<product> product = new List<product>
                {
                    new product{ Id =1, Name="Beans", Type="Food", Price = 280.58 },
                    new product{ Id =2, Name="Jhon", Type="Food", Price = 280.58 },
                    new product{ Id =3, Name="Jack", Type="Food", Price = 280.58 },
                    new product{ Id =4, Name="Rohit", Type="Food", Price = 280.58 },
                    new product{ Id =5, Name="Jerry", Type="Food", Price = 280.58 },
                    new product{ Id =6, Name="Denis", Type="Food", Price = 280.58 },
                }
            }
            


            Console.ReadLine();
        }//Main

    }//program

}//namespace
