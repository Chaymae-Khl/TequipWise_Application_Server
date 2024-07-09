using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface ISapNum
    {
        Task<IEnumerable<SapNumberDto>> GetSapNums();

        Task<IActionResult> AddSuplier(SapNumber sapnum);

        Task<IActionResult> DeleteSapNum(string id);
        Task<IActionResult> UpdateSapNum(string sapId, SapNumber sapnum);

    }
}
