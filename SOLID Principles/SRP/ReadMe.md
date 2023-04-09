# Restaurant Management System

This is a sample project that demonstrates a restaurant order management system implemented in C#. The project follows the principles of Object-Oriented Programming (OOP), including the Single Responsibility Principle (SRP).

## What is the Single Responsibility Principle?

The Single Responsibility Principle (SRP) is a principle of object-oriented design that states that a class should have only one responsibility. In other words, a class should only have one reason to change. This helps to promote modular, reusable, and maintainable code by ensuring that each class is focused on a single responsibility.

## How did we use the Single Responsibility Principle in this project?

In this project, we used the SRP to ensure that each class has only one responsibility:
- `Cashier`: Responsible for managing payments and transactions.
- `Chef`: Responsible for cooking food and updating the inventory when an order is fulfilled.
- `Customer`: Represents a customer at the restaurant and is responsible for placing an order and paying the bill.
- `Ingredient`: Represents an ingredient in the restaurant's inventory.
- `Inventory`: Responsible for keeping track of the ingredient quantities and updating the quantities when a menu item is cooked.
- `Menu`: Responsible for storing and displaying the restaurant menu.
- `MenuItem`: Represents a single item on the menu.
- `Order`: Represents a customer's order and contains the items they have ordered
- `Waiter`: Responsible for taking orders from customers and serving food.