using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Interfaces
{
    internal interface ITeacher
    {
        int Id { get; }
        string Name { get; set; }
        void ReceiveFile(IStudent student, string fileName);
    }
}
