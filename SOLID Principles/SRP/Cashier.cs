using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Cashier
    {
        private decimal _registerBalance;
        public Cashier(decimal registerBalance)
        {
            _registerBalance = registerBalance;
        }
        public bool TakePayment(Order order, decimal amountPaid, out decimal change)
        {
            decimal totalAmount = CalculateOrderPrice(order);
            if(amountPaid >= totalAmount)
            {
                change = amountPaid - totalAmount;
                _registerBalance += totalAmount;
                return true;
            }
            //In case of failed transaction dont take payment
            change = amountPaid;
            return false;
        }
        public decimal GiveBill(Order order)
        {
            return CalculateOrderPrice(order);
        }
        private decimal CalculateOrderPrice(Order order)
        {
            decimal totalPrice = 0;
            foreach (var item in order)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
    }
}
