using Generic.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal("Horse", 3, AnimalType.Harvivore, Gender.Male);
            GenericBehavior<Animal> gb = new GenericBehavior<Animal>();
            Console.WriteLine(gb.GetGenericBehavior<Animal>(a1));
            SpecificBehavior<Animal> sb = new SpecificBehavior<Animal>();
            Console.WriteLine(sb.GetSpecificBehavior<Animal>(a1));
            Console.ReadLine();
        }
    }
}
