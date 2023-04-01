using HW_HighSchool.Interfaces;
using HW_HighSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Services
{
    internal class SchoolService
    {
        public ISchool School { get; init; }

        public string SchoolName => School.Name;
        public SchoolService(ISchool school)
        {
            this.School = school;
        }
        public void AddClassroom(IClassroom classroom)
        {
            School.AddClassroom(classroom);
            Console.WriteLine($"Added classroom {classroom.Name} to the school.");
        }
        public void RemoveClassroom(IClassroom classroom)
        {
            School.RemoveClassroom(classroom);
            Console.WriteLine($"Removed classroom {classroom.Name} from the school.");
        }
        public List<ITeacher> SearchTeacher(string name)
        {
            var teachers = School.Classrooms.Select(classroom => classroom.Teacher)
                                            .Where(teacher => teacher != null && teacher.Name.Contains(name))
                                            .ToList();
            if (teachers.Count > 0)
            {
                Console.WriteLine($"Found {teachers.Count} teachers with name {name} in school {School.Name}:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    var t = teachers[i];
                    Console.WriteLine($"\t{i + 1}: \tName:{t?.Name}\tId:{t?.Id}");
                }
            }
            else
            {
                Console.WriteLine($"Could not find any teachers with name {name} in school {School.Name}");
            }
            return teachers;
        }
        public ITeacher? SearchTeacher(int id)
        {
            var teacher = School.Classrooms.Select(classroom => classroom.Teacher)
                                            .FirstOrDefault(teacher => teacher?.Id == id);
            if (teacher != null)
            {
                Console.WriteLine($"Found teacher with ID {id}: {teacher.Name}.");
            }
            else
            {
                Console.WriteLine($"Could not find a teacher with ID {id}.");
            }

            return teacher;
        }
    }
}
