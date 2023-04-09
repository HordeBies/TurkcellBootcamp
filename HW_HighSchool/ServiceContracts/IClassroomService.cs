using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Classroom entity
    /// </summary>
    internal interface IClassroomService
    {
        /// <summary>
        /// Assigns a teacher to the classroom.
        /// </summary>
        /// <param name="teacher">The teacher to assign to the classroom.</param>
        void AssignTeacher(ITeacher teacher);

        /// <summary>
        /// Removes the assigned teacher from the classroom.
        /// </summary>
        void RemoveTeacher();

        /// <summary>
        /// Adds a student to the classroom.
        /// </summary>
        /// <param name="student">The student to add to the classroom.</param>
        void AddStudent(IStudent student);

        /// <summary>
        /// Removes a student from the classroom.
        /// </summary>
        /// <param name="student">The student to remove from the classroom.</param>
        void RemoveStudent(IStudent student);

        /// <summary>
        /// Sends a file to the teacher from a student.
        /// </summary>
        /// <param name="student">The student who is sending the file.</param>
        /// <param name="filename">The name of the file being sent.</param>
        void SendFileToTeacher(IStudent student, string filename);

        /// <summary>
        /// Searches for a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to search for.</param>
        /// <returns>Returns the student with the given ID or null if not found.</returns>
        IStudent? SearchStudent(int id);

        /// <summary>
        /// Searches for students by their name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>Returns a list of students with the given name.</returns>
        List<IStudent> SearchStudent(string name);

        /// <summary>
        /// Gets all students in the classroom.
        /// </summary>
        /// <returns>Returns a list of all students in the classroom.</returns>
        List<IStudent> GetAllStudents();

    }
}
