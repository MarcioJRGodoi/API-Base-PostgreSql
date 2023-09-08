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
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("Server=silly.db.elephantsql.com;Port=5432;Database=yczascmf;User Id=yczascmf;Password=yrU9L_O6fDkPATpwhDM1O3Rg1npQ_94M;"));
    }
}
