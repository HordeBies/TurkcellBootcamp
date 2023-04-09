using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.Models
{
    internal class School : ISchool
    {
        private static int _idCounter = 0; //mimick auto id generation
        public int SchoolID { get; init; }
        public string Name { get; set; }
        public List<IClassroom> Classrooms { get; private set; }

        public School(string name)
        {
            SchoolID = _idCounter++;
            Name = name;
            Classrooms = new List<IClassroom>();
        }
    }
}
