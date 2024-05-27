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
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationPlant> LocationPlants { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<LocationDepartment> LocationDepartments { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            // Define the relationships

            builder.Entity<LocationPlant>()
                .HasKey(lp => new { lp.LocationId, lp.PlantId });
            builder.Entity<LocationPlant>()
                .HasOne(lp => lp.Location)
                .WithMany(l => l.LocationPlants)
                .HasForeignKey(lp => lp.LocationId);
            builder.Entity<LocationPlant>()
                .HasOne(lp => lp.Plant)
                .WithMany(p => p.LocationPlants)
                .HasForeignKey(lp => lp.PlantId);

            builder.Entity<LocationDepartment>()
                .HasKey(ld => new { ld.LocationId, ld.DepartmentId });
            builder.Entity<LocationDepartment>()
                .HasOne(ld => ld.Location)
                .WithMany(l => l.LocationDepartments)
                .HasForeignKey(ld => ld.LocationId);
            builder.Entity<LocationDepartment>()
                .HasOne(ld => ld.Department)
                .WithMany(d => d.LocationDepartments)
                .HasForeignKey(ld => ld.DepartmentId);

            builder.Entity<LocationDepartment>()
              .HasOne(u => u.Manager)
              .WithMany()
              .HasForeignKey(u => u.ManagerId);

            builder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId);

            builder.Entity<Plant>()
                .HasOne(p => p.Approver)
                .WithMany()
                .HasForeignKey(p => p.ApproverId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Backupaprover)
                .WithMany()
                .HasForeignKey(u => u.BackupaproverId);


            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Manager)
                .WithMany(u => u.Subordinates)
                .HasForeignKey(u => u.ManagerId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.locaId);


        }
       
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
               new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
               new IdentityRole() { Name = "DeptManager", ConcurrencyStamp = "3", NormalizedName = "DeptManager" },
               new IdentityRole() { Name = "HrManager", ConcurrencyStamp = "4", NormalizedName = "HrManager" },
               new IdentityRole() { Name = "FinanceManager", ConcurrencyStamp = "5", NormalizedName = "FinanceManager" },
               new IdentityRole() { Name = "FinanceManager", ConcurrencyStamp = "5", NormalizedName = "ItAnalyst" }

                );
        }
    }
}
