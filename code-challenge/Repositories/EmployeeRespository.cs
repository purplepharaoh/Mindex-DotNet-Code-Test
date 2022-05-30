using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            return _employeeContext.Employees.Include(e => e.DirectReports).ThenInclude(e => e.DirectReports).SingleOrDefault(e => e.EmployeeId == id);
        }

        /// <summary>
        /// Get Employee with direct reports filled
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetReports(string id)
        {
            Employee employee = _employeeContext.Employees.Include(e => e.DirectReports).SingleOrDefault(e => e.EmployeeId == id);
            List<Employee> reports = new List<Employee>();
            if (employee != null && employee.DirectReports != null)
            {
                foreach (Employee report in employee.DirectReports)
                {
                    reports.Add(GetReports(report.EmployeeId));
                }
            }
            return employee;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }

        /// <summary>
        /// Add given Compensation object into the repository
        /// </summary>
        /// <param name="compensation"></param>
        /// <returns></returns>
        public Compensation Add(Compensation compensation)
        {
            compensation.CompensationId = Guid.NewGuid().ToString();
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        /// <summary>
        /// Get Compensation object from the repository by EmployeeID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Compensation GetCompensationById(string id)
        {
            return _employeeContext.Compensations.Include(c => c.Employee).SingleOrDefault(e => e.Employee.EmployeeId == id);
        }

        public Compensation Remove(Compensation compensation)
        {
            return _employeeContext.Remove(compensation).Entity;
        }
    }
}
