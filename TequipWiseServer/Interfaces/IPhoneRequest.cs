using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IPhoneRequest
    {
        Task<IActionResult> PassPhoneRequest(PhoneRequest request);
        Task<IEnumerable<PhoneRequestDTO>> GetRequestsByUserIdAsync(string userId);
    }
}
