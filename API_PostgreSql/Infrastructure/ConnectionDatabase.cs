using API_PostgreSql.Domain.Models;
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
                "Database=bancoTeste;" +  // Adicionei um espaço após o nome do banco
                "User Id=postgres;" +
                "Password=123;");
    }
}
