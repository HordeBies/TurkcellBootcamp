using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Inventory
    {
        private Dictionary<Ingredient, int> _ingredients;
        public Inventory(Dictionary<Ingredient, int> ingredients)
        {
            _ingredients = ingredients;
        }
        public Inventory()
        {
            _ingredients = new();
        }
        public bool IsIngredientAvailable(Ingredient ingredient, int amount)
        {
            if(_ingredients.TryGetValue(ingredient, out int availableAmount))
            {
                return availableAmount > amount;
            }
            return false;
        }
        public bool IsAvailable(Dictionary<Ingredient,int> recipe)
        {
            foreach (var item in recipe)
            {
                if(IsIngredientAvailable(item.Key, item.Value) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public void DecreaseIngredientQuantity(Ingredient ingredient, int amount)
        {
            try
            {
                _ingredients[ingredient] -= amount;
            }
            catch (Exception)
            {
                throw new ArgumentException("Ingredient not found in inventory");
            }
        }
        public void DecreaseIngredientQuantity(Dictionary<Ingredient,int> recipe)
        {
            foreach(var item in recipe)
            {
                DecreaseIngredientQuantity(item.Key,item.Value);
            }
        }
        //TODO: Also introduce a manager that keeps track of low stock ingredients and restocks them
        public void IncreaseIngredientQuantity(Ingredient ingredient, int amount)
        {
            if(_ingredients.TryGetValue(ingredient,out int availableAmount))
            {
                amount += availableAmount;
            }
            _ingredients[ingredient] = amount;
        }
        public void AddIngredient(Ingredient ingredient, int amount)
        {
            IncreaseIngredientQuantity(ingredient, amount);
        }
    }

}
