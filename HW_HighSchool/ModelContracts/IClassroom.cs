namespace HW_HighSchool.ModelContracts
{
    internal interface IClassroom
    {
        int ClassroomID { get; }
        string Name { get; set; }
        ITeacher? Teacher { get; set; }
        List<IStudent> Students { get; }
    }
}
