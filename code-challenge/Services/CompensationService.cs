using System;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Create a new Compensation in the persistence layer
        /// </summary>
        /// <param name="compensation"></param>
        /// <returns></returns>
        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _employeeRepository.Add(compensation);
                _employeeRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /// <summary>
        /// Get existing Compensation by EmployeeID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Compensation GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _employeeRepository.GetCompensationById(id);
            }

            return null;
        }
    }
}
