using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IEquipementRequest
    {

        Task<IActionResult> PassRequest(EquipmentRequest request);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId);
        Task<int> GetRequestCountIdAsync();
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForLocationITApproverAsync(string Itapproverid);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForSapControllerAsync(string controllerId);
        Task<EquipementRequestDTO> GetRequestByIdAsync(int requestId);
        Task<EquipmentRequest?> RequestSupplierOfferAndPU(int equipmentRequestId, EquipmentRequest updatedRequest);
        Task<SubEquipmentRequest?> UpdateSubRequestAsync(int equipmentRequestId, SubEquipmentRequest updatedSubRequest);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForAdminAsync(string controllerId);
        Task<IEnumerable<AssignedAssetDTO>> GetAssignedAssetsForUserAsync(string userId);
        Task<SubEquipmentRequest?> AdminUpdateSubRequestAsync(int equipmentRequestId, SubEquipmentRequest updatedSubRequest);
        Task<EquipmentRequest?> GetRequestByIdAsyncOrig(int equipmentRequestId);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForApproverAsync(string managerId);
    }
}
