﻿using Microsoft.AspNetCore.Identity;
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
        public DbSet<SubEquipmentRequest> subEquipmentRequests { get; set; }
        public DbSet<EquipmentRequest> EquipmentRequests { get; set; }
        public DbSet<PhoneRequest> PhoneRequests { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

        public DbSet<SapNumber> SapNumbers { get; set; }
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
              .HasOne(p => p.ItApprover)
              .WithMany()
              .HasForeignKey(p => p.ITApproverId);
            builder.Entity<Plant>()
             .HasOne(p => p.HRApprover)
             .WithMany()
             .HasForeignKey(p => p.HRApproverId);
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
                .HasMany(u => u.ItRequestToApprove)
                .WithOne(uer => uer.IT)
                .HasForeignKey(uer => uer.itId);
            builder.Entity<ApplicationUser>()
              .HasMany(u => u.DeptMangRequestToApprove)
              .WithOne(uer => uer.DeparManag)
              .HasForeignKey(uer => uer.deptManagId);
            builder.Entity<ApplicationUser>()
              .HasMany(u => u.ControllerRequestToApprove)
              .WithOne(uer => uer.Controller)
              .HasForeignKey(uer => uer.controllerid);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Plant)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.plantId);

            builder.Entity<ApplicationUser>()
              .HasOne(u => u.SapNumber)
              .WithMany(s => s.Users)
              .HasForeignKey(u => u.SapNumberId);
            builder.Entity<ApplicationUser>()
               .HasMany(user => user.UserEquipmentRequests)
               .WithOne(er => er.User)
               .HasForeignKey(er => er.UserId);

            //Equipemnt relations
            // EquipmentRequest relationships
            builder.Entity<EquipmentRequest>()
                .HasMany(er => er.EquipmentSubRequests)
                .WithOne(sub => sub.EquipRequest)
                .HasForeignKey(sub => sub.RequestId);

            builder.Entity<EquipmentRequest>()
                .HasOne(er => er.User)
                .WithMany(user => user.UserEquipmentRequests)
                .HasForeignKey(er => er.UserId);

            // Equipment relationships
            builder.Entity<Equipment>()
                .HasMany(eq => eq.UserEquipmentRequests)
                .WithOne(sub => sub.Equipment)
                .HasForeignKey(sub => sub.EquipmentId);

            builder.Entity<Equipment>()
                .HasOne(eq => eq.supplier)
                .WithMany() // Assuming Supplier is another entity you have
                .HasForeignKey(eq => eq.supplierrid);

            // SubEquipmentRequest relationships
            builder.Entity<SubEquipmentRequest>()
                .HasOne(sub => sub.EquipRequest)
                .WithMany(er => er.EquipmentSubRequests)
                .HasForeignKey(sub => sub.RequestId);

            builder.Entity<SubEquipmentRequest>()
                .HasOne(sub => sub.Equipment)
                .WithMany(eq => eq.UserEquipmentRequests)
                .HasForeignKey(sub => sub.EquipmentId);

            builder.Entity<SubEquipmentRequest>()
                .HasOne(sub => sub.DeparManag)
                .WithMany()
                .HasForeignKey(sub => sub.deptManagId);

            builder.Entity<SubEquipmentRequest>()
                .HasOne(sub => sub.IT)
                .WithMany()
                .HasForeignKey(sub => sub.itId);

            builder.Entity<SubEquipmentRequest>()
                .HasOne(sub => sub.Controller)
                .WithMany()
                .HasForeignKey(sub => sub.controllerid);


            //Supplier Relation
            builder.Entity<Supplier>()
             .HasMany(s => s.Equipements)
             .WithOne(e => e.supplier)
             .HasForeignKey(e => e.supplierrid);
            builder.Entity<Supplier>()
        .HasMany(s => s.subrequests)
        .WithOne(e => e.supplier)
        .HasForeignKey(e => e.supplierrid);
            //Sapnum relatuions
            builder.Entity<SapNumber>()
           .HasOne(p => p.Controller)
            .WithMany()
            .HasForeignKey(p => p.Idcontroller); 
        //phone request relations

        builder.Entity<PhoneRequest>()
        .HasOne(pr => pr.User)
        .WithMany(u => u.PhoneRequests)
        .HasForeignKey(pr => pr.UserId);

        builder.Entity<PhoneRequest>()
        .HasOne(pr => pr.DeparManag)
        .WithMany()
        .HasForeignKey(pr => pr.deptManagId);

        builder.Entity<PhoneRequest>()
        .HasOne(pr => pr.IT)
        .WithMany()
        .HasForeignKey(pr => pr.itId);

        builder.Entity<PhoneRequest>()
        .HasOne(pr => pr.HR)
        .WithMany()
        .HasForeignKey(pr => pr.HRId);



            // maintenace request relations
            builder.Entity<MaintenanceRequest>()
           .HasOne(mr => mr.supplier)
           .WithMany(s => s.MaintenanceRequests) // Assuming Supplier has a collection of MaintenanceRequests
           .HasForeignKey(mr => mr.supplierId)
           .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete if necessary

            builder.Entity<MaintenanceRequest>()
                .HasOne(mr => mr.User)
                .WithMany(u => u.MaintenanceRequests) // Assuming ApplicationUser has a collection of MaintenanceRequests
                .HasForeignKey(mr => mr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MaintenanceRequest>()
                .HasOne(mr => mr.DeptMnag)
                .WithMany(u => u.DeptMangMaintenanceRequests) // Assuming ApplicationUser has a collection for DeptMangMaintenanceRequests
                .HasForeignKey(mr => mr.deptManagId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MaintenanceRequest>()
                .HasOne(mr => mr.IT)
                .WithMany(u => u.ITMaintenanceRequests) // Assuming ApplicationUser has a collection for ITMaintenanceRequests
                .HasForeignKey(mr => mr.itId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MaintenanceRequest>()
                .HasOne(mr => mr.Controller)
                .WithMany(u => u.ControllerMaintenanceRequests) // Assuming ApplicationUser has a collection for ControllerMaintenanceRequests
                .HasForeignKey(mr => mr.ControllerId)
                .OnDelete(DeleteBehavior.Restrict);


        }

       


        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" },
                new IdentityRole { Id = "3", Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "4", Name = "It Approver", ConcurrencyStamp = "4", NormalizedName = "IT APPROVER" },
                new IdentityRole { Id = "5", Name = "Controller", ConcurrencyStamp = "5", NormalizedName = "CONTROLLER" },
                new IdentityRole { Id = "6", Name = "ManagerBackupApprover", ConcurrencyStamp = "6", NormalizedName = "MANAGERBACKUPAPPROVER" },
                new IdentityRole { Id = "7", Name = "ItBackupApprover", ConcurrencyStamp = "7", NormalizedName = "ITBACKUPAPPROVER" },
                new IdentityRole { Id = "8", Name = "ControllerBackupApprover", ConcurrencyStamp = "8", NormalizedName = "CONTROLLERBACKUPAPPROVER" },
                new IdentityRole { Id = "9", Name = "Approver", ConcurrencyStamp = "9", NormalizedName = "APPROVER" },
                new IdentityRole { Id = "10", Name = "HR Approver", ConcurrencyStamp = "10", NormalizedName = "HR APPROVER" }

            );
        }

       
    }
}
