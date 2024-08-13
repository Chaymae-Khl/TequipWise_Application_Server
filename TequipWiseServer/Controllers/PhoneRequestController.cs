using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;
using User.Managmenet.Service.Models;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneRequestController : ControllerBase
    {
        private readonly IPhoneRequest _PhonerequestService;
        public PhoneRequestController(IPhoneRequest requestService)
        {
            _PhonerequestService = requestService;
        }

        [HttpPost("PassPhoneRequest")]
        public async Task<IActionResult> PassRequest([FromBody] PhoneRequest newrequest)
        {
           
          
            // Save the request in the database
             await _PhonerequestService.PassPhoneRequest(newrequest);
         

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Request processed and notification sent." });

        }


    }
}
