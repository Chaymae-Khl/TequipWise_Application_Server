using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminCOntroller : ControllerBase
    {

        private readonly IAuthentication _authService;
        private readonly Iplantsdept _plantdept;
        private readonly Isupplier _supplierService;
        public AdminCOntroller(IAuthentication authService, Iplantsdept plantdept, Isupplier supplierService)
        {
            _authService = authService;
            _plantdept = plantdept;
            _supplierService = supplierService;
        }


        //Users management
        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDetailsDTO>>> GetAllUsers()
        {
            var users = await _authService.GetUsers();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            return await _authService.DeleteUser(userId);
        }

        //nuber of users
        [HttpGet("numberofusers")]
        public async Task<ActionResult<int>> GetNumberofUsers()
        {
            var numusers = await _authService.GetUserCount();
            return Ok(numusers);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserDetailsDTO updatedUserDetails)
        {
          
            var result = await _authService.UpdateUser(userId, updatedUserDetails);
            return result;
        }

        [HttpGet("allRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return await _authService.GetAllRoles();
        }

        [HttpPost("updatePassword/{userId}")]
        public async Task<IActionResult> ChangeUserPassword(string userId, [FromBody] string newPassword)
        {
            var result = await _authService.ChangeUserPassword(userId, newPassword);
            return result;
        }


        //deptartement and plant management
        [HttpPost("AddPlant")]
        public async Task<IActionResult> AddPlant([FromBody] Plant newPlant)
        {
            var result = await _plantdept.AddPlant(newPlant);
            return result;
        }




        //Supplier Managment
        [HttpGet("Suppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliers();
            return Ok(suppliers);
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] Supplier supplier)
        {
            var result = await _supplierService.AddSuplier(supplier);
            return result;
        }


        [HttpPut("updateSupplier/{Id}")]
        public async Task<IActionResult> UpdateSupplier(string Id, [FromBody] Supplier supplier)
        {
            var result = await _supplierService.UpdateUser(Id,supplier);
            return result;
        }
        [HttpDelete("DeleteSupplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            return await _supplierService.DeleteSuplier(id);
        }
        //nuber of suppliers
        [HttpGet("numberofsuppliers")]
        public async Task<ActionResult<int>> GetNumberofSupplires()
        {
            var numsuppliers = await _supplierService.GetSuppliersCount();
            return Ok(numsuppliers);
        }
    }
}
