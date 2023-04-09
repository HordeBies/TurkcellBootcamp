using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Menu
    {
        private readonly List<MenuItem> _menuItems;
        public Menu(List<MenuItem> menuItems)
        {
            _menuItems = menuItems;
        }

        //TODO: handle wrong input or non existent menu item.
        public MenuItem? GetMenuItem(string itemName)
        {
            return _menuItems.FirstOrDefault(item => item.Name == itemName);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (MenuItem item in _menuItems)
            {
                sb.AppendLine($"{item.Name} \t\t:{item.Price:C}");
            }
            return sb.ToString();
        }
    }
}
