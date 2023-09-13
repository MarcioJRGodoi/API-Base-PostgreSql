using API_PostgreSql.Domain.Models.CageAgregate;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using API_PostgreSql.Domain.Models.TurnsAgregate;
using Microsoft.EntityFrameworkCore;

namespace API_PostgreSql.Infrastructure
{
    public class ConnectionDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Turns> Turns { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
                optionsBuilder.UseNpgsql("Server=silly.db.elephantsql.com;Port=5432;Database=kolkghgi;User Id=kolkghgi;Password=du8EnCmSr-GFHO6NXDr2KiPbKHbBgZ2r;");
    }
}
