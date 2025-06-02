using Microsoft.EntityFrameworkCore;
using Member.Domain.Models.Entities;

namespace Member.Infrastructure.Data
{
    public class PostgreeDbContext : DbContext
    {
        public PostgreeDbContext(DbContextOptions<PostgreeDbContext> options)
            : base(options) {}

        public DbSet<Members> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreeDbContext).Assembly);
        }
    }
}
