namespace HW_HighSchool.ModelContracts
{
    internal interface IStudent
    {
        int StudentID { get; }
        string Name { get; set; }
        string SubmitFile(string fileName);
    }
}
