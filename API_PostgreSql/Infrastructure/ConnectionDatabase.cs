using API_PostgreSql.Domain.Models.CageAgregate;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using Microsoft.EntityFrameworkCore;

namespace API_PostgreSql.Infrastructure
{
    public class ConnectionDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cage> Cages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
    }
}
