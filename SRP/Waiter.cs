using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Waiter
    {
        public readonly string Name;
        private Menu _menu;
        private Inventory _inventory;
        private Chef _chef;
        public Waiter(string name, Menu menu, Inventory inventory, Chef chef)
        {
            this.Name = name;
            _menu = menu;
            _inventory = inventory;
            _chef = chef;
        }
        public Order TakeOrder(List<string> orderedItems)
        {
            var order = new Order();
            foreach (var menuItemName in orderedItems)
            {
                var menuItem = _menu.GetMenuItem(menuItemName);
                if (menuItem == null)
                {
                    Console.WriteLine($"{menuItemName} is not on the menu.");
                    continue;
                }
                if (!_inventory.IsAvailable(menuItem.Recipe))
                {
                    Console.WriteLine($"{menuItemName} is not available.");
                    continue;
                }
                _chef.TakeCookingOrder(menuItem);
                order.AddToOrder(menuItem);
            }
            return order;
        }
        public string GiveMenu()
        {
            return _menu.ToString();
        }
    }

}
