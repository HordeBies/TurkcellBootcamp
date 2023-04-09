# School Management System
This is a console-based School Management System that allows you to manage classrooms, students, and teachers in a school.

## Project Overview
The project is built with C# programming language and follows the SOLID principles, clean architecture, and a good OOP approach.

The system consists of the following components:

- `ISchool` interface: Defines the properties and methods that a school should have.
- `IClassroom` interface: Defines the properties and methods that a classroom should have.
- `IStudent` interface: Defines the properties and methods that a student should have.
- `ITeacher` interface: Defines the properties and methods that a teacher should have.
- `School` class: Implements the ISchool interface and represents a school.
- `Classroom` class: Implements the IClassroom interface and represents a classroom in the school.
- `Student` class: Implements the IStudent interface and represents a student in the school.
- `Teacher` class: Implements the ITeacher interface and represents a teacher in the school.
- `IClassroomService` interface: Defines the methods that a classroom service should have.
- `ISchoolService` interface: Defines the methods that a school service should have.
- `ClassroomService` class: Implements the IClassroomService interface and provides methods to manage a classroom.
- `SchoolService` class: Implements the ISchoolService interface and provides methods to manage a school.

The project follows SOLID principles, which stands for:

- `S`ingle Responsibility Principle (SRP): Each class in this project has a single responsibility, and it is focused on doing only one thing. For example, the `Classroom` class is responsible for maintaining information about the classroom, and the `ClassroomService` class is responsible for performing operations on the classroom. Similarly, the `School` class is responsible for maintaining information about the school, and the `SchoolService` class is responsible for performing operations on the school. This ensures that each class is focused on doing one thing and doing it well.

- `O`pen/Closed Principle (OCP): The classes in this project are designed to be open for extension but closed for modification. For example, the `IClassroom` interface defines the basic functionality of a classroom, and any class that implements this interface can add its own behavior without modifying the existing code. Similarly, the `ISchool` interface defines the basic functionality of a school, and any class that implements this interface can add its own behavior without modifying the existing code.

- `L`iskov Substitution Principle (LSP): The classes in this project are designed to be substitutable for their base classes or interfaces. For example, any class that implements the `IClassroom` interface can be used in place of the `Classroom` class, and any class that implements the `ISchool` interface can be used in place of the `School` class.

- `I`nterface Segregation Principle (ISP): The interfaces in this project are designed to be small and specific to the needs of the client. For example, the `IClassroom` interface defines only the basic functionality of a classroom, and the `IClassroomService` interface defines only the operations that can be performed on a classroom. Similarly, the `ISchool` interface defines only the basic functionality of a school, and the `ISchoolService` interface defines only the operations that can be performed on a school.

- `D`ependency Inversion Principle (DIP): The classes in this project depend on abstractions rather than concrete implementations. For example, the `ClassroomService` class depends on the `IClassroom` interface rather than the `Classroom` class, and the `SchoolService` class depends on the `ISchool` interface rather than the `School` class. This ensures that the classes are decoupled from their dependencies, making them more flexible and easier to maintain.

The project also follows a good OOP approach, which involves using encapsulation, inheritance, and polymorphism to write maintainable, reusable, and extensible code.