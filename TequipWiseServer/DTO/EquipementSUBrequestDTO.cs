using System.ComponentModel.DataAnnotations;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class EquipementSUBrequestDTO
    {
        public int SubEquipmentRequestId { get; set; }
        public DateTime SubRequestDate { get; set; }
        public string Comment { get; set; }
        public float? PU { get; set; }
        public float Totale { get; set; }
        
        
        public bool? SubRequestStatus { get; set; }

        public int? QtEquipment { get; set; }

        //departmenent manager request part
        public string? deptManagId { get; set; }
        public string? departementManagerName { get; set; }
        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;
        public string? Departmang_Not_confirmCause { get; set; }

        //Finance request part (Controller)
        public string? controllerid { get; set; }
        public string? ControllerName { get; set; }
        public DateTime? FinanceconfirmedAt { get; set; }
        public bool? FinanceconfirmSatuts { get; set; } = null;

        public string? Finance_Not_confirmCause { get; set; }

        //IT request part
        public string? itId { get; set; }

        public string? ItApproverName { get; set; }

        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }

        public string? EquipementName {  get; set; }
        public int EquipmentId { get; set; }


       
    }
}
