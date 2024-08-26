using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.DTO.KPI_DTO;
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
        //for the KPIS
        Task<List<MonthlyExpenditure>> GetFilteredSubEquipmentRequests(DateTime startDate, DateTime? endDate = null);
        int GetRejectedRequestsCount();
        int GetInProgressRequestsCount();
        int GetWaitingForFinanceApprovalCount();
        int GetWaitingForPRCount();
        int GetWaitingForPOCount();
        int GetApprovedRequestsCount();
        int GetOfferRequestsCount();
        int GetOpenRequestsCount();
    }
}
