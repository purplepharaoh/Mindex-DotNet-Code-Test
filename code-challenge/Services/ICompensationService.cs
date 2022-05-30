using challenge.Models;

namespace challenge.Services
{
    public interface ICompensationService
    {
        /// <summary>
        /// Create a new Compensation in the persistence layer
        /// </summary>
        /// <param name="compensation"></param>
        /// <returns></returns>
        Compensation Create(Compensation compensation);
        /// <summary>
        /// Get existing Compensation by EmployeeID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Compensation GetById(string id);
    }
}
