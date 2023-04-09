
using HW_HighSchool.ModelContracts;

namespace HW_HighSchool.ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating School Entity
    /// </summary>
    internal interface ISchoolService
    {
        /// <summary>
        /// Adds a classroom to the school.
        /// </summary>
        /// <param name="classroom">The classroom to add to the school.</param>
        void AddClassroom(IClassroom classroom);

        /// <summary>
        /// Removes a classroom from the school.
        /// </summary>
        /// <param name="classroom">The classroom to remove from the school.</param>
        void RemoveClassroom(IClassroom classroom);

        /// <summary>
        /// Returns a list of all the classrooms in the school.
        /// </summary>
        /// <returns>A list of all the classrooms in the school.</returns>
        List<IClassroom> GetAllClassrooms();
    }
}
