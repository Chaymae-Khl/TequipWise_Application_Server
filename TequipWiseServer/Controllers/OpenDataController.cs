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
        private readonly ISapNum _sapNumService;

        public OpenDataController(IOpenData plantDepartmentService,ISapNum sapNum)
        {
            _OpenDataService = plantDepartmentService ?? throw new ArgumentNullException(nameof(plantDepartmentService));
            _sapNumService = sapNum;
        }

        
        [HttpGet("locations")]
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
        [HttpGet("getSapNums")]
        public async Task<IActionResult> GetSapNumbers()
        {
            var sapNumbers = await _sapNumService.GetSapNums();
            return Ok(sapNumbers);
        }
    }
}
