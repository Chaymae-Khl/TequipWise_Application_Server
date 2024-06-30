using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IEquipementRequest
    {

        Task<IActionResult> PassRequest(UserEquipmentRequest request);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId);
        Task<int> GetRequestCountByUserIdAsync(string userId);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForLocationITApproverAsync(string Itapproverid);
        Task<IEnumerable<EquipementRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId);
        Task<EquipementRequestDTO> GetRequestByIdAsync(int requestId);
        Task<IActionResult> UpdateRequest(UserEquipmentRequest updatedRequest);
    }
}
