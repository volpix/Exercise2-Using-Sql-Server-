using ApiNetSqlServer.DataTransport;
using ApiNetSqlServer.Models;

namespace ApiNetSqlServer.Services.Interface
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<ResponseDTO> AddEmployee(Employee employee);
        public Task<ResponseDTO> UpdateEmployee(Employee employee);
        public Task<ResponseDTO> DeleteEmployee(int id);
    }
}
