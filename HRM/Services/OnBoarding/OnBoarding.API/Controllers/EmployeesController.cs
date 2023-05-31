using ApplicationCode.Models;
using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //https://localhost:5001/api/employees
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            // return Json data + HTTP Status Code 200
            // serialization c# objects into json objects using System.Text.Json
            if (employees.Any())
            {
                return Ok(employees); // HTTP Status Code 200
            }
            else
            {
                return NotFound(new { error = "No employees found, please try later" }); // HTTP Status Code 404
            }
        }
        //https://localhost:5001/api/employees/1
        [Route("{id:int}", Name = "GetEmployeeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(new { error = $"Employee with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(employee); // HTTP Status Code 200
            }
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var employee = await _employeeService.AddEmployee(model);
            return CreatedAtAction("GetEmployeeDetails", new { controller = "Employees", id = employee }, "Employee Created");
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound(new { error = $"Employee with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(employee); // HTTP Status Code 200
            }
        }


        [Route("Assign")]
        [HttpPost]
        public async Task<IActionResult> Assign(int id)
        {
            var employee = await _employeeService.AssignInterviewer(id);
            if (employee == null)
            {
                return NotFound(new { error = $"Employee with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(employee); // HTTP Status Code 200
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var employee = await _employeeService.UpdateEmployee(id, model);
            if (employee == null)
            {
                return NotFound(new { error = $"Employee with id {id} not found" }); // HTTP Status Code 404
            }
            else
            {
                return Ok(employee); // HTTP Status Code 200
            }
        }

    }
}
