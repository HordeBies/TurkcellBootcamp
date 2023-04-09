# Reservation System Example

This is an example of a reservation system written in C# that demonstrates the Liskov Substitution Principle. The system allows users to make reservations for cars, hotel rooms, and seminar rooms, and provides a `ReservationManager` class to manage and validate these reservations.

## Liskov Substitution Principle

The Liskov Substitution Principle (LSP) is a fundamental principle of object-oriented programming that states that objects of a superclass should be able to be replaced with objects of a subclass without affecting the correctness of the program. In other words, if a program is designed to work with a certain type of object, it should also work correctly with any subtype of that object.

The LSP is important because it allows for polymorphism and code reuse in object-oriented programming. By designing classes that follows LSP, we can create more flexible and maintainable code that is easier to extend and modify over time.

## Implementation

In this project, we used the Liskov Substitution Principle to create three reservation classes - `CarReservation`, `HotelRoomReservation`, and `SeminarRoomReservation` - that all implement the `IReservable` interface, which defines the common fields and methods required for a reservation.

The `ReservationManager` class then uses the `IReservable` interface to manage and validate reservations for cars, hotel rooms, and seminar rooms. The `MakeReservation` methods in the `ReservationManager` class take `IReservable` objects as parameters, which allows any of the three reservation classes to be passed to these methods without affecting the correctness of the program.

By using the `IReservable` interface and following the Liskov Substitution Principle, we have created a flexible and extensible reservation system that can be easily modified and extended over time.

## Conclusion

The Liskov Substitution Principle is an important principle of object-oriented programming that helps us create more flexible, maintainable, and extensible code. By designing classes that follows the LSP, we can ensure that our code is more robust and easier to modify over time.
