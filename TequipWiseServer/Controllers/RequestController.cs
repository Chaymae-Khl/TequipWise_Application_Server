using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Helpers;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IEquipementRequest _requestService;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEquipment _equipmentService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;


        public RequestController(IEquipementRequest requestService, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager, IEquipment equipmentService, IMapper mapper, AppDbContext dbContext)
        {
            _requestService = requestService;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
            _equipmentService = equipmentService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public string FixedemailLink = "http://localhost:4200/";

        [HttpPost("PassEquipemntRequest")]
        public async Task<IActionResult> PassRequest([FromBody] EquipmentRequest newrequest)
        {
            // Get the authenticated user details
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null || userDetails.Department == null || userDetails.Department.Manager == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User's department or department manager information is missing." });
            }

            //assight the request to the autheticated user
            newrequest.UserId = userDetails.Id;
            //set the acual date
            newrequest.RequestDate=DateTime.Now;
            // Save the request in the database
            var result = await _requestService.PassRequest(newrequest);
            if (result is OkObjectResult == false)
            {
                return result;
            }

            var haveApprover = userDetails.ApproverActive;
            var haveBackupApprover = userDetails.ManagerBackupApproverActive;


            if (haveApprover == true)
            {
                var ApproverEmail = userDetails.ApproverEmail;
                if (string.IsNullOrEmpty(ApproverEmail))
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "Approver email is missing." });
                }

                var approver = await _userManager.FindByEmailAsync(ApproverEmail);
                if (approver != null)
                {
                    var deptmangLink = FixedemailLink + "RequestConfirmation";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate.Replace("{{resetLink}}", deptmangLink);
                    var message = new Message(new string[] { approver.Email }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = $"Equipment request confirmation link sent to your approver by email." });
                }
            }


            else
            {
                if (haveBackupApprover == true)
                {
                    var backupApproverEmail = userDetails.ManagerBackupApproverEmail;
                    if (string.IsNullOrEmpty(backupApproverEmail))
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                            new Response { Status = "Error", Message = "Department manager's email is missing." });
                    }

                    var manager = await _userManager.FindByEmailAsync(backupApproverEmail);
                    if (manager != null)
                    {
                        var deptmangLink = FixedemailLink + "RequestConfirmation";
                        var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                        var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                        var emailContent = emailTemplate.Replace("{{resetLink}}", deptmangLink);

                        var message = new Message(new string[] { manager.Email }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
                        _emailService.SendEmail(message);

                        return StatusCode(StatusCodes.Status200OK,
                            new Response { Status = "Success", Message = $"Equipment request confirmation link sent to the manager of you department by email." });
                    }
                }

                else
                {
                    var deptmanagerEmail = userDetails.ManagerEmail;
                    if (string.IsNullOrEmpty(deptmanagerEmail))
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "Department manager's email is missing." });
                    }
                    var manager = await _userManager.FindByEmailAsync(deptmanagerEmail);
                    if (manager != null)
                    {
                        // Generate a token for confirming the request (not for password reset)
                        //var token = await _userManager.GenerateUserTokenAsync(manager, TokenOptions.DefaultProvider, "EquipmentRequest");
                        var deptmangLink = FixedemailLink + "RequestConfirmation";
                        var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                        var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                        var emailContent = emailTemplate.Replace("{{resetLink}}", deptmangLink);


                        var message = new Message(new string[] { manager.Email }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
                        _emailService.SendEmail(message);

                        return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Equipment request confirmation link sent to the manager of you department by email." });
                    }
                }
            }
            return result;

        }

        ////get the requests of the authenticated user

        [HttpGet("GetUserRequests")]
        public async Task<IActionResult> GetUserRequests()
        {
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User details are missing." });
            }

            var userRequests = await _requestService.GetRequestsByUserIdAsync(userDetails.Id);

            return Ok(userRequests);
        }

        //[HttpGet("GetUserRequestCount")]
        //public async Task<IActionResult> GetUserRequestCount()
        //{
        //    var userResult = await _authService.GetAuthenticatedUserAsync();

        //    if (userResult is UnauthorizedResult)
        //    {
        //        return Unauthorized();
        //    }

        //    var okResult = userResult as OkObjectResult;
        //    if (okResult == null || okResult.Value == null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
        //    }

        //    var userDetails = okResult.Value as UserDetailsDTO;
        //    if (userDetails == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User details are missing." });
        //    }

        //    var requestCount = await _requestService.GetRequestCountByUserIdAsync(userDetails.Id);

        //    return Ok(new { Count = requestCount });
        //}

        //[HttpGet("DepartmentRequests")]
        //public async Task<IActionResult> GetDepartmentRequests()
        //{
        //    var userResult = await _authService.GetAuthenticatedUserAsync();

        //    if (userResult is UnauthorizedResult)
        //    {
        //        return Unauthorized();
        //    }

        //    var okResult = userResult as OkObjectResult;
        //    if (okResult == null || okResult.Value == null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
        //    }

        //    var userDetails = okResult.Value as UserDetailsDTO;
        //    if (userDetails == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User details are missing." });
        //    }

        //    var roles = await _userManager.GetRolesAsync(new ApplicationUser { Id = userDetails.Id });

        //    IEnumerable<EquipementRequestDTO> requests;

        //    if (roles.Contains("Manager"))
        //    {
        //        requests = await _requestService.GetRequestsForDepartmentManagerAsync(userDetails.Id);
        //    }
        //    else if (roles.Contains("It Approver"))
        //    {
        //        requests = await _requestService.GetRequestsForLocationITApproverAsync(userDetails.Id);
        //    }
        //    else
        //    {
        //        return Forbid();
        //    }

        //    return Ok(requests);
        //}

        //[HttpPut("UpdateEquipemntRequest")]
        //public async Task<IActionResult> UpdateRequest([FromBody] UserEquipmentRequest updatedRequest)
        //{
        //    // Retrieve the authenticationuser info

        //    var userResult = await _authService.GetAuthenticatedUserAsync();


        //    var okResult = userResult as OkObjectResult;
        //    if (okResult == null || okResult.Value == null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
        //    }

        //    var userDetails = okResult.Value as UserDetailsDTO;
        //    if (userDetails == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User details are missing." });
        //    }



        //    // Retrieve the current request details from the database
        //    var currentrequestDetails = await _requestService.GetRequestByIdAsync(updatedRequest.UserEquipmentRequestId);
        //    //get the user Email
        //    var userEmail = currentrequestDetails.User.Email;
        //    //get the itAPprover Email
        //    var ItApproverEmail = currentrequestDetails.User.Plant.ItApprover.Email;

        //    if (currentrequestDetails == null)
        //    {
        //        return NotFound(new Response { Status = "Error", Message = "Equipement not found." });
        //    }

        //    // Check if a specific field 'DepartmangconfirmStatus' has been modified
        //    if (updatedRequest.DepartmangconfirmStatus != currentrequestDetails.DepartmangconfirmStatus)
        //    {

        //        updatedRequest.deptManagId = userDetails.Id;
        //        updatedRequest.DepartmangconfirmedAt = DateTime.Now;
        //        var ItApproverLink = FixedemailLink + "RequestConfirmation";

        //        //when the manager approver an emai should be sent to the it approver
        //        if (ItApproverEmail != null)
        //        {

        //            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
        //            var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
        //            var emailContent = emailTemplate.Replace("{{resetLink}}", ItApproverLink)
        //                     .Replace("{{TeNum}}", currentrequestDetails.NameOfUser);

        //            var message = new Message(new string[] { ItApproverEmail }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
        //            _emailService.SendEmail(message);
        //        }

        //    }

        //    //change the global status of the request to false if the manager or the itapprover or the financeappror reject
        //    if (updatedRequest.DepartmangconfirmStatus == false || updatedRequest.ITconfirmSatuts == false || updatedRequest.FinanceconfirmSatuts == false)
        //    {
        //        var rejectionlink = FixedemailLink + "EquipmentList";
        //        var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RejectionTemplate.html");
        //        var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
        //        var emailContent = emailTemplate.Replace("{{resetLink}}", rejectionlink)
        //            .Replace("{{equipment}}", currentrequestDetails.EquipmentName)
        //            .Replace("{{UserName}}", currentrequestDetails.NameOfUser);
        //        updatedRequest.RequestStatus = false;

        //        //send the rejection email to the user

        //        var message = new Message(new string[] { userEmail }, "Equipment Request Rejection", emailContent, isHtml: true);
        //        _emailService.SendEmail(message);
        //        Console.WriteLine("=================== the request is rejcted ");
        //    }


        //    var result = await _requestService.UpdateRequest(updatedRequest);

        //    return result;
        //}

        //[HttpPost("UploadSupplierOffer")]
        //public async Task<IActionResult> UploadSupplierOffer([FromForm] int requestId, [FromForm] IFormFile file)
        //{
        //    var fileUploadHelper = new FileUploadHelper();

        //    string filePath;
        //    try
        //    {
        //        filePath = await fileUploadHelper.UploadFileAsync(file);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(new Response { Status = "Error", Message = ex.Message });
        //    }

        //    // Update the database record with the file path
        //    var request = await _dbContext.UserEquipmentRequests.FindAsync(requestId);
        //    if (request == null)
        //        return NotFound(new Response { Status = "Error", Message = "Request not found." });

        //    request.SupplierOffer = filePath;
        //    _dbContext.Entry(request).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();

        //    return Ok(new Response { Status = "Success", Message = "File uploaded and request updated successfully!" });
        //}

        [HttpGet("EquipemntName")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllEquipemntName()
        {
            var Equipmentname = await _equipmentService.GetEquipemntInfoAsync();
            return Ok(Equipmentname);
        }
    }


}
