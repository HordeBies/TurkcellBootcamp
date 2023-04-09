namespace HW_HighSchool.ModelContracts
{
    internal interface ITeacher
    {
        int TeacherID { get; }
        string Name { get; set; }
        void ReceiveFile(IStudent student, string fileName);
    }
}
