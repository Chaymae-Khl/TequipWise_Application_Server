using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.DTO.ApprovalDTO;
using TequipWiseServer.DTO.KPI_DTO;
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
        private readonly NotificationService _notificationService;
        private readonly Isupplier _supplierService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RequestController(IEquipementRequest requestService, 
            IAuthentication authService, IEMailService emailService, 
            UserManager<ApplicationUser> userManager,
            IEquipment equipmentService, IMapper mapper, 
            AppDbContext dbContext,
            NotificationService notificationService,
            Isupplier supplierService, IWebHostEnvironment hostingEnvironment)
        {
            _requestService = requestService;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
            _equipmentService = equipmentService;
            _mapper = mapper;
            _dbContext = dbContext;
            _notificationService = notificationService;
            _supplierService = supplierService;
            _hostingEnvironment = hostingEnvironment;
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
            newrequest.RequestDate = DateTime.Now;

            foreach(var subreq in newrequest.EquipmentSubRequests)
            {
                subreq.SubRequestDate= DateTime.Now;
            }
            // Save the request in the database
            var result = await _requestService.PassRequest(newrequest);
            if (result is OkObjectResult == false)
            {
                return result;
            }
            await _notificationService.SendNotificationAsync(userDetails.Id, "Your request has been sent!");

            var haveApprover = userDetails.ApproverActive;
            var haveBackupApprover = userDetails.ManagerBackupApproverActive;
            Console.WriteLine("=============="+userDetails.TeNum);
            
            if (haveApprover == true)
            {
                var ApproverEmail = userDetails.ApproverEmail;
                if (string.IsNullOrEmpty(ApproverEmail))
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "Approver email is missing." });
                }

                var approver = await _userManager.FindByEmailAsync(ApproverEmail);
                Console.WriteLine("=================="+approver.TeNum);

                if (approver != null && userDetails!=null)
                {
                    var deptmangLink = FixedemailLink + "RequestConfirmation";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate
                           .Replace("{{resetLink}}", deptmangLink);
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

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Request processed and notification sent." });

        }
        [HttpGet("GetRequestCount")]
        public async Task<ActionResult<int>> GetNumberofUsers()
        {
            var numReq = await _requestService.GetRequestCountIdAsync();
            return Ok(numReq);
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
        [HttpGet("user-assets")]
        public async Task<IActionResult> GetUserITAssets()
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

            var userRequests = await _requestService.GetAssignedAssetsForUserAsync(userDetails.Id);

            return Ok(userRequests);
        }


        [HttpGet("DepartmentRequests")]
        public async Task<IActionResult> GetDepartmentRequests()
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
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User details are missing." });
            }

            var roles = await _userManager.GetRolesAsync(new ApplicationUser { Id = userDetails.Id });

            IEnumerable<EquipementRequestDTO> requests;

            if (roles.Contains("Manager") || roles.Contains("ManagerBackupApprover"))
            {
                requests = await _requestService.GetRequestsForDepartmentManagerAsync(userDetails.Id);
            }
            else if (roles.Contains("It Approver") || roles.Contains("ItBackupApprover"))
            {
                requests = await _requestService.GetRequestsForLocationITApproverAsync(userDetails.Id);
            }
            else if (roles.Contains("Controller") || roles.Contains("ControllerBackupApprover"))
            {
                requests = await _requestService.GetRequestsForSapControllerAsync(userDetails.Id);
            }
            else if (roles.Contains("Admin"))
            {
                requests = await _requestService.GetRequestsForAdminAsync(userDetails.Id);
            }
            else if (roles.Contains("Approver"))
            {
                requests = await _requestService.GetRequestsForApproverAsync(userDetails.Id);
            }
            else
            {
                return Forbid();
            }

            return Ok(requests);
        }

        

        [HttpPut("{equipmentRequestId}/subrequests/{subRequestId}")]
        public async Task<IActionResult> UpdateSubRequest(int equipmentRequestId, int subRequestId, [FromBody] SubEquipmentRequest updatedSubRequest)
        {
            Console.WriteLine("=====================" + updatedSubRequest.supplierrid);
            if (subRequestId != updatedSubRequest.SubEquipmentRequestId)
            {
                return BadRequest("Sub-request ID mismatch.");
            }

            var result = await _requestService.UpdateSubRequestAsync(equipmentRequestId, updatedSubRequest);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{equipmentRequestId}/Adminsubrequests/{subRequestId}")]
        public async Task<IActionResult> AdminUpdateSubRequest(int equipmentRequestId, int subRequestId, [FromBody] SubEquipmentRequest updatedSubRequest)
        {
            Console.WriteLine("=====================" + updatedSubRequest.supplierrid);
            if (subRequestId != updatedSubRequest.SubEquipmentRequestId)
            {
                return BadRequest("Sub-request ID mismatch.");
            }

            var result = await _requestService.AdminUpdateSubRequestAsync(equipmentRequestId, updatedSubRequest);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPut("ItOfferAndPrice/{equipmentRequestId}")]
        public async Task<IActionResult> RequestSupplierOfferAndPUPrice(int equipmentRequestId, IFormFile file, [FromForm] string updatedRequestJson)
        {
            EquipmentRequest updatedRequest;
            try
            {
                updatedRequest = JsonConvert.DeserializeObject<EquipmentRequest>(updatedRequestJson);
            }
            catch (JsonException ex)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid JSON format" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (file != null)
            {
                var fileUploadHelper = new FileUploadHelper();
                string filePath;
                try
                {
                    filePath = await fileUploadHelper.UploadFileAsync(file);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(new Response { Status = "Error", Message = ex.Message });
                }
                updatedRequest.SupplierOffer = filePath;
            }

            var result = await _requestService.RequestSupplierOfferAndPU(equipmentRequestId, updatedRequest);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("EquipemntName")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllEquipemntName()
        {
            var Equipmentname = await _equipmentService.GetEquipemntInfoAsync();
            return Ok(Equipmentname);
        }
        //[HttpGet("{subRequestId}")]
        //public async Task<IActionResult> GetSubRequestById(int subRequestId)
        //{
        //    var subRequest = await _requestService.GetSubRequestByIdAsync(subRequestId);
        //    if (subRequest == null)
        //    {
        //        return NotFound(new Response { Status = "Error", Message = "Sub-Request not found." });
        //    }

        //    return Ok(subRequest);
        //}
    

    [HttpPost("TestNotification")]
    public async Task<IActionResult> TestNotification()
    {
        var userId = "7d4b8e80-05eb-4be7-98b4-9bfb4e7e750d"; // Replace with a valid user ID
        var message = "Test notification";
        await _notificationService.SendNotificationAsync(userId, message);
        return Ok("Notification sent");
    }



    //get Id and name of supplier
    [HttpGet("SuppliersName")]
    public async Task<ActionResult<IEnumerable<dynamic>>> GetAllSuppliersName()
    {
        var suppliersname = await _supplierService.GetSupplierInfoAsync();
        return Ok(suppliersname);
    }



        //For KPIs
        [HttpGet("monthly-expenditure")]
        public async Task<ActionResult<List<MonthlyExpenditure>>> GetFilteredSubEquipmentRequests(
     [FromQuery] DateTime startDate,
     [FromQuery] DateTime? endDate = null)
        {
            var data = await _requestService.GetFilteredSubEquipmentRequests(startDate, endDate);
            return Ok(data);
        }

        [HttpGet("counts")]
        public IActionResult GetRequestCounts()
        {
            var counts = new
            {
                Open = _requestService.GetOpenRequestsCount(),
                InProgress = _requestService.GetInProgressRequestsCount(),
                WaitingForFinanceApproval = _requestService.GetWaitingForFinanceApprovalCount(),
                WaitingForPR = _requestService.GetWaitingForPRCount(),
                WaitingForPO = _requestService.GetWaitingForPOCount(),
                Approved = _requestService.GetApprovedRequestsCount(),
                Rejected = _requestService.GetRejectedRequestsCount(),
            };

            return Ok(counts);
        }

    }
}