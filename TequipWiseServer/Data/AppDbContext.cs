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
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<LocationDepartment> LocationDepartments { get; set; }
        public DbSet<UserEquipmentRequest> UserEquipmentRequests { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            // Define the relationships
            //Location/Plant/Departemnt Relations
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

            //user relations
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

       

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.UserEquipmentRequests)
                .WithOne(uer => uer.User)
                .HasForeignKey(uer => uer.UserId);

            builder.Entity<Equipment>()
                .HasMany(e => e.UserEquipmentRequests)
                .WithOne(uer => uer.Equipment)
                .HasForeignKey(uer => uer.EquipmentId);



            //Supplier Relation
            builder.Entity<Supplier>()
             .HasMany(s => s.Equipements)
             .WithOne(e => e.supplier)
             .HasForeignKey(e => e.supplierrid);


        }
       
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
               new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
               new IdentityRole() { Name = "DeptManager", ConcurrencyStamp = "3", NormalizedName = "DeptManager" },
               new IdentityRole() { Name = "HrManager", ConcurrencyStamp = "4", NormalizedName = "HrManager" },
               new IdentityRole() { Name = "FinanceManager", ConcurrencyStamp = "5", NormalizedName = "FinanceManager" },
               new IdentityRole() { Name = "ItAnalyst", ConcurrencyStamp = "6", NormalizedName = "ItAnalyst" },
               new IdentityRole() { Name = "Controller", ConcurrencyStamp = "7", NormalizedName = "Controller" }

                );
        }
    }
}
