using ApiNetSqlServer.DataTransport;
using ApiNetSqlServer.DbAccess;
using ApiNetSqlServer.Models;
using ApiNetSqlServer.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiNetSqlServer.Services
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using(var ctx = _context)
                {
                    employees = await ctx.Employees.ToListAsync();
                    return employees;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el empleado.", ex);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            try
            {
                using(var ctx = _context)
                {
                    employee = await ctx.Employees.FindAsync(id) ?? new Employee();
                    return employee;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el empleado.", ex);
            }
        }

        public async Task<ResponseDTO> AddEmployee(Employee employee)
        {
            ResponseDTO responseDTO = new ResponseDTO() { IsSuccess = false};
            try
            {
                using(var ctx = _context)
                {

                    ctx.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    responseDTO.IsSuccess = true;
                    responseDTO.Message = "Se agrego correctamente el empleado";
                }
            }
            catch(Exception ex)
            {
                responseDTO.Message ="Ocurrio un error al agregar el empleado " + ex.Message;
            }
            return responseDTO;
        }

        public async Task<ResponseDTO> UpdateEmployee(Employee employee)
        {
            ResponseDTO responseDTO = new ResponseDTO() { IsSuccess = false };
            try
            {
                using (var ctx = _context)
                {
                    Employee employeeUpdate = new Employee();

                    employeeUpdate = await ctx.Employees.FindAsync(employee.EmployeeId) ?? new Employee();

                    if (employeeUpdate != null)
                    {

                    employeeUpdate.FirstName = employee.FirstName == null ? employeeUpdate.FirstName : employee.FirstName;
                    employeeUpdate.LastName = employee.LastName == null ? employeeUpdate.LastName : employee.LastName;
                    employeeUpdate.Salary = employee.Salary > 0 ? employee.Salary : employeeUpdate.Salary;

                    await _context.SaveChangesAsync();
                    responseDTO.IsSuccess = true;
                    responseDTO.Message = "Se actualizo correctamente el empleado";

                    }else
                    {
                        responseDTO.Message = "No se encontro el empleado";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDTO.Message = "Ocurrio un error al actualizar el empleado " + ex.Message;
            }
            return responseDTO;
        }

        public async Task<ResponseDTO> DeleteEmployee(int id)
        {
            ResponseDTO responseDTO = new ResponseDTO() { IsSuccess = false };
            try
            {
                using (var ctx = _context)
                {
                    var employee = await ctx.Employees.FindAsync(id);
                    if (employee != null)
                    {
                        ctx.Employees.Remove(employee);
                        await ctx.SaveChangesAsync();

                        responseDTO.IsSuccess = true;
                        responseDTO.Message = "Se elimino correctamente el empleado";
                        return responseDTO;
                    }

                    responseDTO.Message = "No se encontro el empleado";
                }
            }
            catch (Exception ex)
            {
                responseDTO.Message = "Ocurrio un error al eliminar el empleado " + ex.Message;
            }
            return responseDTO;
        }
    }
}
