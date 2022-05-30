using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(String id);

        /// <summary>
        /// Get Employee with direct reports filled
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetReports(string id);
        Employee Add(Employee employee);
        Employee Remove(Employee employee);
        Task SaveAsync();

        Compensation GetCompensationById(string id);
        Compensation Add(Compensation employee);
        Compensation Remove(Compensation employee);
    }
}