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
        Task<IEnumerable<AssignedPhoneDTO>> GetAssignedPhonesForUserAsync(string userId);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsForAdminAsync(string AdminId);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsForApproverAsync(string managerId);
        Task<IActionResult> UpdatePhoneRequestforAdmin(int requestId, PhoneRequest updatedRequest);
        Task<int> GetRequestPhneCountIdAsync();
        int GetInProgressRequestsCount();
        int GetWaitingForHRRequestsCount();
        int GetOpenRequestsCount();
        int GetApprovedRequestsCount();
        int GetWaitingForITRequestsCount();
        int GetRejectedRequestsCount();
    }
}
