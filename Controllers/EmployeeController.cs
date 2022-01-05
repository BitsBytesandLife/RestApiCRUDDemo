using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.Controllers
{
    [Route("Demo/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("Api/[controller]")]

        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("Api/[controller]/{id}")]

        public IActionResult GetEmployees(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if(employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with Id: {id} was not found");
        }

        [HttpPost]
        [Route("Api/[controller]/")]

        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("Api/[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with Id: {id} was not found");
        }


        [HttpPatch]
        [Route("Api/[controller]/{id}")]

        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var currentEmployee = _employeeData.GetEmployee(id);

            if (currentEmployee != null)
            {
                employee.Id = currentEmployee.Id;
                _employeeData.EditEmployee(employee);
                return Ok(employee);
            }

            return NotFound($"Employee with Id: {id} was not found");
        }
    }
}
