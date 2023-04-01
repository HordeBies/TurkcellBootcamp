using HW_HighSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_HighSchool.Models
{
    internal class Student : IStudent
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public Student(string name)
        {
            Name = name;
        }
        public string SubmitFile(string filename)
        {
            string file = filename;
            Console.WriteLine($"{Name} is submitting file: {file}");
            return file; 
        }

    }
}
