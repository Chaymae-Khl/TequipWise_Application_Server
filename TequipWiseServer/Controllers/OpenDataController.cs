using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.Interfaces;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenDataController : ControllerBase
    {
        private readonly IOpenData _OpenDataService;

        public OpenDataController(IOpenData plantDepartmentService)
        {
            _OpenDataService = plantDepartmentService ?? throw new ArgumentNullException(nameof(plantDepartmentService));
        }

        
        [HttpGet("plants")]
        public async Task<IActionResult> GetPlants()
        {
            try
            {
                var plants = await _OpenDataService.GetPlants();
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
       
    }
}
