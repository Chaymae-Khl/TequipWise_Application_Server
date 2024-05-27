using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface ILocation
    {
        Task<IActionResult> AddPlant(Plant newPlant);
        Task<IActionResult> CreateLocation(LocationDTO locationDto);
    }
}
