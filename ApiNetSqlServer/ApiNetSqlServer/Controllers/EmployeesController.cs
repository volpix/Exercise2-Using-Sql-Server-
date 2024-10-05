using ApiNetSqlServer.DataTransport;
using ApiNetSqlServer.Models;
using ApiNetSqlServer.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetSqlServer.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get_All_Employees")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public async Task<IActionResult> GetEmployees()
        {
            var employee = await _employeeRepository.GetAllEmployees();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Get employees by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get_Employee_By_Id")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("Add_Employee")]
        [ProducesResponseType(typeof(ResponseDTO), 200)]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
            return Ok(await _employeeRepository.AddEmployee(employee));
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("Update_Employee")]
        [ProducesResponseType(typeof(ResponseDTO), 200)]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            return Ok(await _employeeRepository.UpdateEmployee(employee));
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete_Employee")]
        [ProducesResponseType(typeof(ResponseDTO), 200)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _employeeRepository.DeleteEmployee(id));
        }
    }
}
