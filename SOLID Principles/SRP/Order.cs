using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Order : IEnumerable<MenuItem>
    {
        //TODO: can modift it to Dictionary<MenuItem,int> to make orders accept multiple instances of 1 menu item, like 2 of the same drinks, 2 of the same meals
        private readonly List<MenuItem> _menuItems;
        public Order()
        {
            _menuItems = new();
        }
        public void AddToOrder(MenuItem menuItem)
        {
            if (_menuItems.Contains(menuItem))
            {
                throw new ArgumentException("You already ordered " + menuItem.Name);
            }
            _menuItems.Add(menuItem);
        }
        public void RemoveFromOrder(MenuItem menuItem)
        {
            if (!_menuItems.Remove(menuItem))
            {
                throw new ArgumentException("You didn't order "+ menuItem.Name);
            }
        }

        #region Iterating Over Order Implementation
        public IEnumerator<MenuItem> GetEnumerator()
        {
            return _menuItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
