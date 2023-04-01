using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Interfaces
{
    internal interface ISchool
    {
        string Name { get; }
        List<IClassroom> Classrooms { get; }
        void AddClassroom(IClassroom classroom);
        void RemoveClassroom(IClassroom classroom);
    }
}
