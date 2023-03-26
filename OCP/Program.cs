using OCP.Characters;
using OCP.Enemies;
using OCP.Neutral;

//Characters
Mage gandalf = new Mage(
    name: "Bladorthin",
    health:100,
    mana:10,
    attackPower:10
);

Vampire dracula = new Vampire(
    name:"Dracula",
    health:50,
    attackPower:10
);

//Enemies
Dragon dracarys = new Dragon(health:100, attackPower:10);
Goblin gobby = new Goblin(health:20, attackPower:10);

//Neutral entities
Dummy dummy = new Dummy();
Guard guard = new Guard();

dummy.TakeDamage(100);

guard.Attack(dummy);

Console.WriteLine("\nFight between {0} and {1} begin!",gandalf.Name,dracarys.GetType().Name);
while (gandalf.IsAlive && dracarys.IsAlive)
{
    gandalf.Attack(dracarys);
    if (!dracarys.IsAlive)
        continue;
    dracarys.Attack(gandalf);
    Console.WriteLine();
}

Console.WriteLine("\nFight between {0} and {1} begin!", dracula.Name, gobby.GetType().Name);
while(dracula.IsAlive && gobby.IsAlive)
{
    dracula.Attack(gobby);
    if (!gobby.IsAlive)
        continue;
    gobby.Attack(dracula);
    Console.WriteLine();
}
