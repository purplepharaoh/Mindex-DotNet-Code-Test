using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface IEmployeeService
    {
        Employee GetById(String id);
        /// <summary>
        /// Get employee with reporting structure filled out
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetReports(string id);
        Employee Create(Employee employee);
        Employee Replace(Employee originalEmployee, Employee newEmployee);
    }
}
