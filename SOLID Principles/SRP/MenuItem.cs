using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Dictionary<Ingredient, int> Recipe { get; set; }
        public MenuItem(string name, decimal price, Dictionary<Ingredient, int> recipe)
        {
            Name = name;
            Price = price;
            Recipe = recipe;
        }
    }
}
