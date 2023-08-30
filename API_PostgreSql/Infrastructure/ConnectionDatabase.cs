using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.EntityFrameworkCore;

namespace API_PostgreSql.Infrastructure
{
    public class ConnectionDatabase : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
                optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=teste;" + 
                "User Id=postgres;" +
                "Password=123;");
    }
}
