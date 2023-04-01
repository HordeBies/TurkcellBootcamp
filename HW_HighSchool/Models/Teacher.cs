using HW_HighSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Models
{
    internal class Teacher : ITeacher
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public Teacher(string name)
        {
            Name = name;
        }
        public void ReceiveFile(IStudent student, string fileName) //should take file object itself instead of the name but this will do for now
        {
            Console.WriteLine($"{Name} received file '{fileName}' from student '{student.Name}'.");
        }
    }
}
