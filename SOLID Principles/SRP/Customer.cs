using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Customer
    {
        private readonly string _name;
        private decimal _balance;
        public Customer(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }
        public Order PlaceOrder(Waiter waiter, List<string> items)
        {
            Console.WriteLine($"Customer {_name} is placing an order...");
            return waiter.TakeOrder(items);
        }
        public void Eat()
        {
            Console.WriteLine($"Customer {_name} is eating.");
        }
        public void PayBill(Cashier cashier, Order order)
        {
            var bill = cashier.GiveBill(order);
            Console.WriteLine($"Bill for {_name}'s order: {bill:C}");
            if (cashier.TakePayment(order, _balance, out _balance))
            {
                Console.WriteLine($"Payment successful! Change: {_balance:C}");
            }
            else
            {
                Console.WriteLine("Payment failed, not enough balance.");
            }

        }


    }
}
