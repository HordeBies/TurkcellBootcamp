using HW_HighSchool.ModelContracts;
using HW_HighSchool.ServiceContracts;

namespace HW_HighSchool.Services
{
    internal class SchoolService : ISchoolService
    {
        public ISchool School { get; init; }

        public SchoolService(ISchool school)
        {
            this.School = school;
        }

        public void AddClassroom(IClassroom classroom)
        {
            School.Classrooms.Add(classroom);
            Console.WriteLine($"Added classroom {classroom.Name} to the school.");
        }

        public void RemoveClassroom(IClassroom classroom)
        {
            if(School.Classrooms.Remove(classroom))
                Console.WriteLine($"Removed classroom {classroom.Name} from the school.");
            else
                Console.WriteLine($"Could not remove classroom {classroom.Name} from the school.");
        }

        public List<IClassroom> GetAllClassrooms()
        {
            return School.Classrooms;
        }
    }
}
