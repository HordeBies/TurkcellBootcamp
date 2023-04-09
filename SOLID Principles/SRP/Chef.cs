using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Chef
    {
        private Queue<MenuItem> _mealsToCook;
        private Inventory _inventory;
        public Chef(Inventory inventory)
        {
            _mealsToCook = new();
            _inventory = inventory;
        }

        public void TakeCookingOrder(MenuItem menuItem)
        {
            _mealsToCook.Enqueue(menuItem);
            _inventory.DecreaseIngredientQuantity(menuItem.Recipe);
            //TODO: Introduce async cooking to enable real life simulation with meal cooking times etc. but its not necessary at the moment.
            CookMenuItem(); 
        }
        public void CookMenuItem()
        {
            while(_mealsToCook.Count> 0)
            {
                var meal = _mealsToCook.Dequeue();
                //Cook the meal here, Use async Task.Delay maybe
            }
        }
    }
}
