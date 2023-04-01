using HW_HighSchool.Interfaces;
using HW_HighSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Services
{
    internal class ClassroomService
    {
        public IClassroom Classroom { get; init; }

        public ClassroomService(IClassroom classroom)
        {
            this.Classroom = classroom;
        }

        public void AssignTeacher(ITeacher teacher)
        {
            Classroom.AssignTeacher(teacher);
            Console.WriteLine($"Assigned teacher {teacher.Name} to classroom {Classroom.Name}");
        }

        public void RemoveTeacher()
        {
            Classroom.RemoveTeacher();
            Console.WriteLine($"Removed teacher {Classroom.Teacher?.Name} from classroom {Classroom.Name}");
        }

        public void AddStudent(IStudent student)
        {
            Classroom.AddStudent(student);
            Console.WriteLine($"Added student {student.Name} to classroom {Classroom.Name}");
        }

        public void RemoveStudent(IStudent student)
        {
            Classroom.RemoveStudent(student);
            Console.WriteLine($"Removed student {student.Name} from classroom {Classroom.Name}");
        }

        public void SendFileToTeacher(IStudent student, string filename)
        {
            var file = student.SubmitFile(filename);
            Classroom.Teacher?.ReceiveFile(student, file);
            Console.WriteLine($"Student {student.Name} sent file {filename} to teacher {Classroom.Teacher?.Name} in classroom {Classroom.Name}");
        }
        public IStudent? SearchStudent(int id)
        {
            var student = Classroom.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine($"Found student with ID {id} in classroom {Classroom.Name}: {student.Name}");
            }
            else
            {
                Console.WriteLine($"Could not find student with ID {id} in classroom {Classroom.Name}");
            }
            return student;
        }

        public List<IStudent> SearchStudent(string name)
        {
            var students = Classroom.Students.Where(s => s.Name.Contains(name)).ToList();
            if (students.Count > 0)
            {
                Console.WriteLine($"Found {students.Count} students with name {name} in classroom {Classroom.Name}:");
                for (int i = 0; i < students.Count; i++)
                {
                    var s = students[i];
                    Console.WriteLine($"\t{i+1}: \tName:{s.Name}\tId:{s.Id}");
                }
            }
            else
            {
                Console.WriteLine($"Could not find any students with name {name} in classroom {Classroom.Name}");
            }
            return students;
        }


    }
}
