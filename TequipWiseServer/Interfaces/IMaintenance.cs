using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IMaintenance
    {
        Task<IActionResult> PassMaintenanceRequest(MaintenanceRequest request);
        Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForITAsync(string userId);
        Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForAdminAsync(string controllerId);
        Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForSapControllerAsync(string controllerId);
        Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForApproverAsync(string managerId);
        Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId);
        Task<MaintenanceRequest?> UpdateRequestAsync(int equipmentRequestId, MaintenanceRequest updatedRequest, IFormFile? file);
        Task<IActionResult> UpdateMaintenanceRequestforAdmin(int requestId, MaintenanceRequest updatedRequest);
        int GetOpenMaintenanceRequestsCount();
        int GetWaitingForFinanceApprovalMaintenanceRequestsCount();
        int GetWaitingForPRMaintenanceRequestsCount();
        int GetWaitingForPOMaintenanceRequestsCount();
        int GetApprovedMaintenanceRequestsCount();
        int GetRejectedMaintenanceRequestsCount();
        Task<int> GetRequestCount();
        Task<IActionResult> UpdateMaintenanceRequestgenerale( MaintenanceRequest Request);

    }
}
