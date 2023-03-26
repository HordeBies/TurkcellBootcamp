# RPG Combat System

This is a sample project that demonstrates an RPG combat system implemented in C#. The project follows the principles of Object-Oriented Programming (OOP), including the Open/Closed Principle (OCP).

## What is the Open/Closed Principle?

The Open/Closed Principle (OCP) is a principle of object-oriented design that states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification. In other words, existing code should not be modified to add new features or behavior, but should instead be extended by adding new code that works alongside the existing code.

The OCP promotes modular, extensible, and maintainable code by encouraging developers to write code that can be easily extended without breaking existing functionality. This can be achieved by using techniques such as abstraction, inheritance, and interfaces.

## How did we use the Open/Closed Principle in this project?

In this project, we used the Open/Closed Principle to implement a combat system for a role-playing game (RPG). The combat system involves two types of entities: characters (such as mages and vampires) and enemies (such as goblins and dragons). Each entity can attack and take damage, but different entities may have different attack powers and behaviors.

To implement the combat system in a way that follows the OCP, we used the following techniques:

- Abstraction: We defined interfaces (`IAttacker` and `ITargetable`) to represent the behavior of entities that can attack and be attacked. These interfaces allow us to extend the behavior of entities without modifying existing code.

- Inheritance: We used inheritance to create a base `Character` and `Enemy` class that contains common properties and behavior for all characters and enemies. We then created derived classes (`Mage` and `Vampire` for characters, `Dragon` and `Goblin` for monsters) that extend these base classes and add additional behaviors.

- Extension: We have `Character` and `Enemy` base classes that implements the `ITargetable` and `IAttacker` interfaces. This allows us to add new types of characters and enemies to the game without modifying existing code.

By using these techniques, we were able to create a modular, extensible, and maintainable combat system that follows the principles of the Open/Closed Principle.
