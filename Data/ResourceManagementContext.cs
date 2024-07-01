using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Entities;

namespace ResourceManagementSystem.Data
{
    public class ResourceManagementContext(DbContextOptions<ResourceManagementContext> options)
        : DbContext(options)
    {
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<Location> Locations => Set<Location>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(

                new { Id = 1, Name = "Compartment No 14" },
                new { Id = 2, Name = "Compartment No 15" },
                new { Id = 3, Name = "Compartment No 16" },
                new { Id = 4, Name = "Compartment No 17" },
                new { Id = 5, Name = "Compartment No 18" }
             );
        }
    }
}
