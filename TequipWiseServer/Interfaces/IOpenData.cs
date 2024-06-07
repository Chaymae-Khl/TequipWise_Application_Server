using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.Models.Authentication.SignUp;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IOpenData
    {
        Task<IEnumerable<LocationDTO>> GetPlants();
    }
}
