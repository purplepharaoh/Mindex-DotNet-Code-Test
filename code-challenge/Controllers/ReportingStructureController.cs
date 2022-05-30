using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/ReportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IEmployeeService employeeService, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetEmployeeById(String id)
        {
            _logger.LogDebug($"Received ReportingStructure get request for employee '{id}'");

            var employee = _employeeService.GetReports(id);

            if (employee == null)
                return NotFound();

            var reportingStruct = _reportingStructureService.Create(employee);

            return Ok(reportingStruct);
        }
    }
}
