using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TequipWiseServer.Models;

namespace TequipWiseServer.Data
{
    public class AppDbContext :IdentityDbContext<IdentityUser>
    {
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            // Define the relationships
            builder.Entity<Department>()
                .HasOne(d => d.Plant)
                .WithMany(p => p.Departments);

            builder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
               new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }
    }
}
