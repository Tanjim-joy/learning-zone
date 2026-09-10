using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
{
    public interface ISpecificBehavior<T>
    {
        string GetSpecificBehavior<T>(T obj) where T : Animal;
    }
}