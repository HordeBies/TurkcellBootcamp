using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.Models
{
    internal class Student : IStudent
    {
        private static int _idCounter = 0; //mimick auto id generation
        public int StudentID { get; init; }
        public string Name { get; set; }
        public Student(string name)
        {
            StudentID = _idCounter++;
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
