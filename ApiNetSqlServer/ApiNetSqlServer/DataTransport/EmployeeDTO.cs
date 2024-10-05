using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace ApiNetSqlServer.DataTransport
{
    public class EmployeeDTO
    {
        [JsonIgnore]
        [SwaggerSchema(ReadOnly = true)]
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
