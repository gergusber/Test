using Microsoft.EntityFrameworkCore;
using TravelPort.Domain.Models;

namespace TravelPort.Infrastructure.Db
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options): base(options)
        {
        }

        public DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasKey(c => new { c.Id});
        }
    }
}