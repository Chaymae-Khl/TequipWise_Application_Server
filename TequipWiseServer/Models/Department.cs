﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId {  get; set; }
        public string DepartmentName { get; set; }
        public string? EmailManger { get; set; }
        public bool Status {  get; set; }

        [JsonIgnore]
        public ICollection<ApplicationUser>? Users { get; set; }

        public ICollection<LocationDepartment>? LocationDepartments { get; set; }

        // Foreign key to the manager (optional if using EF Core conventions)
        public string? ManagerId { get; set; }

        // Navigation property to the manager
        [JsonIgnore]

        public ApplicationUser? Manager { get; set; }

    }
}
