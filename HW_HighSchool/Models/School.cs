using HW_HighSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Models
{
    internal class School : ISchool
    {
        public string Name { get; private set; }
        public List<IClassroom> Classrooms { get; private set; }

        public School(string name)
        {
            Name = name;
            Classrooms = new List<IClassroom>();
        }
        public void AddClassroom(IClassroom classroom)
        {
            Classrooms.Add(classroom);
        }
        public void RemoveClassroom(IClassroom classroom)
        {
            Classrooms.Remove(classroom);
        }

    }
}
