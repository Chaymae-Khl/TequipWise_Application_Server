﻿namespace TequipWiseServer.DTO
{
    public class DepartmentDTO
    {
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public string? ManagerName { get; set; }
        public string? EmailManger { get; set; }

        public string? ManagerId { get; set; }

    }
}
