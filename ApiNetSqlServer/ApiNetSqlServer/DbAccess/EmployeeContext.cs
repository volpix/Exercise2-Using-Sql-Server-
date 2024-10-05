using ApiNetSqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNetSqlServer.DbAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
