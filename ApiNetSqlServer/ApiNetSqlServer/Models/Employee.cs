using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace ApiNetSqlServer.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
