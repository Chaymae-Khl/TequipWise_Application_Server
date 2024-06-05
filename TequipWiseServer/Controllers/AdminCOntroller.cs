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
        private readonly ILocation _locationService;
        private readonly Isupplier _supplierService;
        private readonly IEquipment _equipmentService;

        public AdminCOntroller(IAuthentication authService, ILocation locationService, Isupplier supplierService, IEquipment equipmentService)
        {
            _authService = authService;
            _locationService = locationService;
            _supplierService = supplierService;
            _equipmentService = equipmentService;
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


        //Location (Plant-Depart) Management
         //Location plant traitement
        //Add location with there department and plants
        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddPlant([FromBody] LocationDTO newLOcation)
        {
            var result = await _locationService.CreateLocation(newLOcation);
            return result;
        }
         //Delete location and the association between it and the plant and department 
        [HttpDelete("DeleteLOcation/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            return await _locationService.DeleteLocation(id);
        }

        [HttpPost("add-plant-to-location/{locationId}")]
        public async Task<IActionResult> AddPlantToLocation(int locationId, [FromBody] PlantDto plantDto)
        {
            return await _locationService.AddPlantToLocation(locationId, plantDto);
        }

        [HttpPut("updatePlantLocation/{locationId}/plants/{plantId}")]
        public async Task<IActionResult> UpdatePlantLocation(int locationId, int plantId, [FromBody] PlantDto plantDto)
        {
            var result = await _locationService.UpdatePlantOfLocation(locationId, plantId, plantDto);
            return result;
        }

        [HttpDelete("DeletePlantofLocation/{locationId}/plants/{plantId}")]
        public async Task<IActionResult> DeletePlantofLocation(int locationId, int plantId)
        {
            return await _locationService.DeletePlantofLocation(locationId, plantId);
        }

        //Location departement traitement
        //add departement to the location

        [HttpPost("add-departement-to-location/{locationId}")]
        public async Task<IActionResult> AdddepartementToLocation(int locationId, [FromBody] DepartmentDTO deptDto)
        {
            return await _locationService.AddDepartementToLocation(locationId, deptDto);
        }
        //update teh departement of teh location
        [HttpPut("updateDepartmentLocation/{locationId}/Department/{deptId}")]
        public async Task<IActionResult> UpdateDepartementLocation(int locationId, int deptId, [FromBody] DepartmentDTO deptDto)
        {
            var result = await _locationService.UpdateDepartementOfLocation(locationId, deptId, deptDto);
            return result;
        }




        // get the name of plants

        [HttpGet("Plants")]
        public async Task<ActionResult<IEnumerable<PlantDto>>> GetAllPlants()
        {
            var plants = await _locationService.GetPlants();
            return Ok(plants);
        }

        [HttpGet("Departments")]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAllDepartments()
        {
            var depts = await _locationService.GetDepartments();
            return Ok(depts);
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
          //number of suppliers
        [HttpGet("numberofsuppliers")]
        public async Task<ActionResult<int>> GetNumberofSupplires()
        {
            var numsuppliers = await _supplierService.GetSuppliersCount();
            return Ok(numsuppliers);
        }
        //get Id and name of supplier
        [HttpGet("SuppliersName")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllSuppliersName()
        {
            var suppliersname = await _supplierService.GetSupplierInfoAsync();
            return Ok(suppliersname);
        }




        //Equipment Mangement

        [HttpGet("AllEquipements")]
        public async Task<IActionResult> GetAllEquipemnts()
        {
            var equipements = await _equipmentService.GetEquipments();
            return Ok(equipements);
        } 

        [HttpPost("AddEquipment")]
        public async Task<IActionResult> AddNewEquipment([FromBody] Equipment equipment)
        {
            return await _equipmentService.AddEquipment(equipment);

        }

        [HttpPut("updateEquipment/{Id}")]
        public async Task<IActionResult> UpdateEquipement(int Id, [FromBody] Equipment equipment)
        {
            var result = await _equipmentService.UpdateEquipemnt(Id, equipment);
            return result;
        }

        [HttpDelete("DeleteEquipment/{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            return await _equipmentService.RemoveEquipment(id);
        }

        [HttpGet("NumberOfEquipment")]
        public async Task<ActionResult<int>> GetNumberofEquipements()
        {
            var numberOfEquipements= await _equipmentService.GetEquipmentCount();
            return Ok(numberOfEquipements);
        }


    }
}
