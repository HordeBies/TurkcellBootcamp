using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.Models
{
    internal class Teacher : ITeacher
    {
        private static int _idCounter = 0; //mimick auto id generation
        public int TeacherID { get; init; }
        public string Name { get; set; }
        public Teacher(string name)
        {
            TeacherID = _idCounter++;
            Name = name;
        }
        public void ReceiveFile(IStudent student, string fileName) //should take file object itself instead of the name but this will do for now
        {
            Console.WriteLine($"{Name} received file '{fileName}' from student '{student.Name}'.");
        }
    }
}
