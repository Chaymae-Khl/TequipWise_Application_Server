using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IEquipementRequest
    {

        Task<IActionResult> PassRequest(EquipmentRequest request);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId);
        Task<int> GetRequestCountByUserIdAsync(string userId);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForLocationITApproverAsync(string Itapproverid);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForSapControllerAsync(string controllerId);
        Task<EquipementRequestDTO> GetRequestByIdAsync(int requestId);
        Task<EquipmentRequest?> RequestSupplierOfferAndPU(int equipmentRequestId, EquipmentRequest updatedRequest);
        Task<SubEquipmentRequest?> UpdateSubRequestAsync(int equipmentRequestId, SubEquipmentRequest updatedSubRequest);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForAdminAsync(string controllerId);
    }
}
