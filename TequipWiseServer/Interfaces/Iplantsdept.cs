using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface Iplantsdept
    {
        Task<IActionResult> AddPlant(Plant newPlant);
    }
}
