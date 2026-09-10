using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Gen
{
    public class GenericBehavior<T> : IGenericBehavior<T>
    {
        public object AnimalType { get; private set; }

        public string GetGenericBehavior<T>(T obj)
        {
            if (obj is Animal)
            {
                Animal a = obj as Animal;
                switch (a.Type)
                {
                    case AnimalType.Harvivore:
                        return "Docile, Plant eaters";
                    case AnimalType.Carvivore:
                        return "Canine, Meat eaters";
                    case AnimalType.Omnivore:
                        return "Adaptable, Eating everything edible";
                    default:
                        return "Unknown animal type";

                }
            }
            else
            {
                return "Unknown type";
            }
        }
    }
}
