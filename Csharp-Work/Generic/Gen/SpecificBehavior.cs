using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Gen
{
    public class SpecificBehavior<T> : ISpecificBehavior<T>
    {
        public object AnimalType { get; private set; }

        public string GetSpecificBehavior<T>(T obj) where T : Animal

        {
            switch (obj.Type)
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
    }
}
