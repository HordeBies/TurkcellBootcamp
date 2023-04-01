using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Interfaces
{
    internal interface IStudent
    {
        int Id { get; }
        string Name { get; set; }
        string SubmitFile(string fileName);
    }
}
