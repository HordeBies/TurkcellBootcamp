using SRP;

#region Ingredients
Ingredient cheese = new Ingredient("Cheese");
Ingredient tomatoSauce = new Ingredient("Tomato Sauce");
Ingredient dough = new Ingredient("Dough");
Ingredient pepperoni = new Ingredient("Pepperoni");
Ingredient mushrooms = new Ingredient("Mushrooms");
Ingredient onions = new Ingredient("Onions");
Ingredient basil = new Ingredient("Basil");

List<Ingredient> ingredients = new List<Ingredient>()
{
    cheese,
    tomatoSauce,
    dough,
    pepperoni,
    mushrooms,
    onions,
    basil
};
#endregion

#region Inventory
Inventory inventory = new Inventory();
inventory.AddIngredient(cheese, 20);
inventory.AddIngredient(tomatoSauce, 20);
inventory.AddIngredient(dough, 20);
inventory.AddIngredient(pepperoni, 10);
inventory.AddIngredient(mushrooms, 10);
inventory.AddIngredient(onions, 10);
inventory.AddIngredient(basil, 10);

#endregion

#region Menu
MenuItem margheritaPizza = new("Margherita Pizza", 15m, new () { {basil, 1 } , { cheese, 1}, { tomatoSauce , 2}, { dough, 2 } });
MenuItem pepperoniPizza = new("Pepperoni Pizza", 17m, new () { {pepperoni, 1 } , { cheese, 1}, { tomatoSauce , 2}, { dough, 2 } });
MenuItem mushroomPizza = new("Mushroom Pizza", 13m, new () { {mushrooms, 1 } , { cheese, 1}, { tomatoSauce , 2}, { dough, 2 } });
MenuItem panini = new("Tomato and Cheese Panini", 20m, new() { {tomatoSauce, 2 }, {cheese, 2 }, {dough,1 } , {onions,1 }, { mushrooms, 1 } });

List<MenuItem> menuItems = new() { margheritaPizza, pepperoniPizza, mushroomPizza, panini };
Menu menu = new(menuItems);
#endregion

#region Staff
Chef chef = new(inventory);
Waiter waiter1 = new("Kürşat", menu, inventory, chef);
Waiter waiter2 = new("Irem", menu, inventory, chef);
Cashier cashier = new(100m);
#endregion

Customer customer1 = new Customer("Bies",100m);
Customer customer2 = new("Hasansio", 50m);
Customer customer3 = new("Alberto", 130m);

//Imagine we are working with a terminal or forms, inputs are in string format so i used strings as a way to communicate for customers
var order1 = customer1.PlaceOrder(waiter1, new() { "Margherita Pizza", "Tomato and Cheese Panini" });
customer1.Eat();
customer1.PayBill(cashier, order1);
Console.WriteLine();

_ = waiter2.GiveMenu(); // a customer can ask for a menu and waiter can return the menu as a string and we can send that to corresponding customer here
var order2 = customer2.PlaceOrder(waiter2, new() { "Pepperoni Pizza", "Tomato and Cheese Panini" });
customer2.Eat();
customer2.PayBill(cashier, order2);
Console.WriteLine();

var order3 = customer3.PlaceOrder(waiter1, new() { "Margherita Pizza", "Pepperoni Pizza", "Mushroom Pizza", "Tomato and Cheese Panini" });
customer3.Eat();
customer3.PayBill(cashier, order3);
Console.WriteLine();

var order4 = customer1.PlaceOrder(waiter2, new() { "Pepperoni Pizza" });
customer1.Eat();
customer1.PayBill(cashier, order4);