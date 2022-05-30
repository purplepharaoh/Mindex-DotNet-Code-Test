using System;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService 
    {
        private readonly ILogger<EmployeeService> _logger;

        public ReportingStructureService(ILogger<EmployeeService> logger)
        {
            _logger = logger;
        }

        public ReportingStructure Create(Employee employee)
        {
            ReportingStructure reportingStructure = null;
            if (employee != null)
            {
                reportingStructure = new ReportingStructure();
                reportingStructure.employee = employee;

                reportingStructure.numberOfReports = CalculateNumberOfReports(employee);
            }

            return reportingStructure;
        }

        private int CalculateNumberOfReports(Employee employee)
        {
            //exit early with value of 0 if there are no reports
            if (employee.DirectReports == null) return 0;

            int num = employee.DirectReports.Count;

            foreach (Employee e in employee.DirectReports)
            {
                num += CalculateNumberOfReports(e);
            }

            return num;
        }
    }
}
