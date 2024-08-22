using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IPhoneRequest
    {
        Task<IActionResult> PassPhoneRequest(PhoneRequest request);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsByUserIdAsync(string userId);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsForPlantITApproverAsync(string Itapproverid);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsForPlantHRApproverAsync(string HRapproverid);
        Task<IActionResult> UpdatePhoneRequest(int requestId, PhoneRequest updatedRequest);
    }
}
