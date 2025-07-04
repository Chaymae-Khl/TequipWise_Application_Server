﻿using System.Text.Json.Serialization;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class UserDetailsDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string TeNum { get; set; }
        public bool? backupActive { get; set; }
        public bool? ApproverActive { get; set; }

        public string? plant_name { get; set; }
        public string? Backupaprover_Name { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerEmail { get; set; }
        public string? ItApproverEmail { get; set; }
        public string? ItApproverName { get; set; }

        public string? ApproverEmail { get; set; }
        public string? ManagerBackupApproverEmail { get; set; }
        public bool? ManagerBackupApproverActive { get; set; }
        public int locaId { get; set; }
        public int? SapNumberId { get; set; }
        public string? SapNumb { get; set; }


        public Location? Location { get; set; }
        public Department? Department { get; set; }
        public List<string> Roles { get; set; }

        public virtual ICollection<SubordinateDTO>? Subordinates { get; set; }

        public string DepartmentName { get; set; }
        public string? LocationName { get; set; }
    }
    
    
    
    
    
    public class SubordinateDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string TeNum { get; set; }
    }
}