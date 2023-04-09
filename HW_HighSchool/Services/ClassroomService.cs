using HW_HighSchool.ServiceContracts;
using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.Services
{
    internal class ClassroomService : IClassroomService
    {
        public IClassroom Classroom { get; init; }

        public ClassroomService(IClassroom classroom)
        {
            this.Classroom = classroom;
        }

        public void AssignTeacher(ITeacher teacher)
        {
            Classroom.Teacher = teacher;
            Console.WriteLine($"Assigned teacher {teacher.Name} to classroom {Classroom.Name}");
        }

        public void RemoveTeacher()
        {
            var teacher = Classroom.Teacher;
            Classroom.Teacher = null;
            Console.WriteLine($"Removed teacher {teacher?.Name} from classroom {Classroom.Name}");
        }

        public void AddStudent(IStudent student)
        {
            Classroom.Students.Add(student);
            Console.WriteLine($"Added student {student.Name} to classroom {Classroom.Name}");
        }

        public void RemoveStudent(IStudent student)
        {
            if (Classroom.Students.Remove(student))
                Console.WriteLine($"Removed student {student.Name} from classroom {Classroom.Name}");
            else
                Console.WriteLine($"Could not remove student {student.Name} from classroom {Classroom.Name}");
        }

        public List<IStudent> GetAllStudents()
        {
            return Classroom.Students;
        }

        public void SendFileToTeacher(IStudent student, string filename)
        {
            if(!Classroom.Students.Contains(student))
            {
                Console.WriteLine($"Student {student.Name} is not in classroom {Classroom.Name}");
                return;
            }
            var file = student.SubmitFile(filename);
            Classroom.Teacher?.ReceiveFile(student, file);
            Console.WriteLine($"Student {student.Name} sent file {filename} to teacher {Classroom.Teacher?.Name} in classroom {Classroom.Name}");
        }

        public IStudent? SearchStudent(int id)
        {
            var student = Classroom.Students.FirstOrDefault(s => s.StudentID == id);
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
                    Console.WriteLine($"\t{i + 1}: \tName:{s.Name}\tId:{s.StudentID}");
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
