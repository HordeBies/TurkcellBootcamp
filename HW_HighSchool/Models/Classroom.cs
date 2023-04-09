using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.Models
{
    internal class Classroom : IClassroom
    {
        private static int _idCounter = 0; //mimick auto id generation
        public int ClassroomID { get; set; }
        public string Name { get; set; } //ChangeClassroomName(string newName)
        public ITeacher? Teacher { get; set; }
        public List<IStudent> Students { get; }

        public Classroom(string name)
        {
            ClassroomID = _idCounter++;
            Name = name;
            Students = new List<IStudent>();
        }
    }
}
