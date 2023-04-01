using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Interfaces
{
    internal interface IClassroom
    {
        string Name { get; }
        ITeacher? Teacher { get; }
        List<IStudent> Students { get; }
        void AssignTeacher(ITeacher teacher);
        void RemoveTeacher();
        void AddStudent(IStudent student);
        void RemoveStudent(IStudent student);
    }
}
