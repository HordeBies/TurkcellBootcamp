using HW_HighSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Models
{
    internal class Classroom : IClassroom
    {
        public string Name { get; private set; } //ChangeClassroomName(string newName)
        public ITeacher? Teacher { get; private set; }
        public List<IStudent> Students { get; }

        public Classroom(string name)
        {
            Name = name;
            Students = new List<IStudent>();
        }
        public void AddStudent(IStudent student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(IStudent student)
        {
            Students.Remove(student);
        }
        public void AssignTeacher(ITeacher teacher)
        {
            Teacher = teacher;
        }
        public void RemoveTeacher()
        {
            Teacher = null;
        }
    }
}
