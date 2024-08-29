using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.DTO
{
    public class MaintenanceRequestDTO
    {
        public int MaintenanceId { get; set; }
        public DateTime RequestDate { get; set; }

        public string? description { get; set; }
        public bool? RequestStatus { get; set; } = null;

        public string? equipmentType { get; set; }
        public string? sn { get; set; }
        public string? damageTYpe { get; set; }
        public string? offer { get; set; }

        public string? supplierId { get; set; }
        public string? UserId { get; set; }
        public string? deptManagId { get; set; }
        public string? itId { get; set; }
        public string? ControllerId { get; set; }

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;

        public string? Departmang_Not_confirmCause { get; set; }

        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }

        public string? requestUserName {  get; set; }

        public string? supplierName { get; set; }
        public string? departementManagerName { get; set; }
        public string? ControllerName { get; set; }
        public string? ItApproverName { get; set; }


        public float? PU { get; set; } = 0;
        public string? GL { get; set; }

        public string? CC { get; set; }
        public string? order { get; set; }
        public string? PONum { get; set; }

        public string? PRNum { get; set; }

        public bool? PR_Status { get; set; } = null;
        public string? PR_Not_ConfirmCause { get; set; }

        public DateTime? ControllerconfirmedAt { get; set; }
        public bool? ControllerconfirmSatuts { get; set; } = null;

        public string? Controller_Not_confirmCause { get; set; }
    }
}
