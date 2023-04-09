using HW_HighSchool.ModelContracts;
using HW_HighSchool.Models;
using HW_HighSchool.ServiceContracts;
using HW_HighSchool.Services;

// create a school
ISchool school = new School("Turkcell Akademi");

// create a school service
ISchoolService schoolService = new SchoolService(school);

// create a classroom
IClassroom classroom1 = new Classroom("ASP.Net");
IClassroom classroom2 = new Classroom("C#");

// create classroom services
IClassroomService classroom1Service = new ClassroomService(classroom1);
IClassroomService classroom2Service = new ClassroomService(classroom2);

// add the classroom to the school
schoolService.AddClassroom(classroom1);
schoolService.AddClassroom(classroom2);

// create a teacher
ITeacher teacher1 = new Teacher("Ali Türk");
ITeacher teacher2 = new Teacher("Ak Şahin");

// assign a teacher to the classroom
classroom1Service.AssignTeacher(teacher1);
classroom2Service.AssignTeacher(teacher2);

// create some students
IStudent student1 = new Student("Hasan Denis");
IStudent student2 = new Student("Bies");
IStudent student3 = new Student("Lourante");
IStudent student4 = new Student("Mehmet Demirci");

// add the students to the classroom
classroom1Service.AddStudent(student1);
classroom1Service.AddStudent(student2);
classroom2Service.AddStudent(student3);
classroom2Service.AddStudent(student4);

// search for a student by name
List<IStudent> students1 = classroom1Service.SearchStudent("Hasan");
List<IStudent> students2 = classroom2Service.SearchStudent("Mehmet");

// search for a student by id
IStudent? search_student1 = classroom1Service.SearchStudent(student2.StudentID);
IStudent? search_student2 = classroom2Service.SearchStudent(student3.StudentID);

// get all students in the classroom
List<IStudent> students_in_classroom1 = classroom1Service.GetAllStudents();
List<IStudent> students_in_classroom2 = classroom2Service.GetAllStudents();

// send a file to the teacher
classroom1Service.SendFileToTeacher(student1, "Homework.docx");
classroom2Service.SendFileToTeacher(student3, "Homework.docx");

// remove a student from the classroom
classroom1Service.RemoveStudent(student1);
classroom2Service.RemoveStudent(student3);

// remove a teacher from the classroom
classroom1Service.RemoveTeacher();
classroom2Service.RemoveTeacher();

// get all classrooms in the school
List<IClassroom> classrooms = schoolService.GetAllClassrooms();

// remove a classroom from the school
schoolService.RemoveClassroom(classroom1);
