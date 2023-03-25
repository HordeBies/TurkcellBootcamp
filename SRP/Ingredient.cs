using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Ingredient
    {
        public string Name { get; private set; }
        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
