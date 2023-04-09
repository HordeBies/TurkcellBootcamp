namespace HW_HighSchool.ModelContracts
{
    internal interface ISchool
    {
        int SchoolID { get; }
        string Name { get; set; }
        List<IClassroom> Classrooms { get; }
    }
}
