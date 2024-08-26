using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.DTO
{
    public class PhoneRequestDTO
    {
        public int PhoneRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public string? Comment { get; set; }


        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? RequestStatus { get; set; } = null;

        public string? ForWho { get; set; }

        public string? NewHireName { get; set; }
        public string? NewHireEmail { get; set; }

        public string? AssetType { get; set; }
        public string? phoneRequestType { get; set; }
        public string? ReplacemnetType { get; set; }


        //foreing keys
        public string? UserId { get; set; }
        public string? NmaeOfUser { get; set; }

        public string? deptManagId { get; set; }
        public string? departementManagerName { get; set; }

        public string? itId { get; set; }
        public string? ItApproverName { get; set; }

        public string? HRId { get; set; }
        public string? HRApproverName { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;

        public string? Departmang_Not_confirmCause { get; set; }

        //It manager request part

        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }
        public string? IMI { get; set; }
        public string? Modele { get; set; }
        public string? TelNumber { get; set; }
        public DateTime? AssetReceiveByEMployeAt { get; set; }
        public bool? ReceptionStatus { get; set; } = null;

        //HR request part
        public DateTime? HRconfirmedAt { get; set; }
        public bool? HRconfirmSatuts { get; set; } = null;

        public string? HR_Not_confirmCause { get; set; }
        public string? EmployeeCategorie { get; set; }

    }
}
