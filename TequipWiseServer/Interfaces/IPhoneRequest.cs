using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IPhoneRequest
    {
        Task<IActionResult> PassPhoneRequest(PhoneRequest request);
    }
}
