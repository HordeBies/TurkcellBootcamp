using HW_HighSchool.Interfaces;
using HW_HighSchool.Models;
using HW_HighSchool.Services;

// create a school
ISchool school = new School("Turkcell Akademi");

// create a school service
SchoolService schoolService = new SchoolService(school);

// create a classroom
IClassroom classroom1 = new Classroom("ASP.Net");

// create a classroom service
ClassroomService classroomService = new ClassroomService(classroom1);

// add the classroom to the school
schoolService.AddClassroom(classroom1);

// create a teacher
ITeacher teacher1 = new Teacher("Ali Türk") { Id = 0 }; //assume id is created by EF database etc.

// assign a teacher to the classroom
classroomService.AssignTeacher(teacher1);

// create some students
IStudent student1 = new Student("Hasan Denis") { Id = 0};
IStudent student2 = new Student("Bies") { Id = 1};
IStudent student3 = new Student("Lourante") { Id = 2};
IStudent student4 = new Student("Mehmet Demirci") { Id = 3};

// add the students to the classroom
classroomService.AddStudent(student1);
classroomService.AddStudent(student2);
classroomService.AddStudent(student3);
classroomService.AddStudent(student4);

// search for a teacher by name
List<ITeacher> teachers = schoolService.SearchTeacher("Ali");

// search for a teacher by id
ITeacher? teacher = schoolService.SearchTeacher(teacher1.Id);

// search for a student by name
List<IStudent> students = classroomService.SearchStudent("Hasan");

// search for a student by id
IStudent? student = classroomService.SearchStudent(student2.Id);

// send a file to the teacher
classroomService.SendFileToTeacher(student3, "Homework.docx");