using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TequipWiseServer.Controllers;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;
using User.Managmenet.Service.Services;

namespace MyApp.Tests
{
    public class AdminTest
    {

        private readonly Mock<IAuthentication> _mockAuthService;
        private readonly Mock<ILocation> _mockPlantDeptService;
        private readonly Mock<Isupplier> _mockSupplierService;
        private readonly Mock<IEquipment> _mockEquipmentService;
        private readonly Mock<IEMailService> _mockEmailService;
        private readonly AdminCOntroller _controller;

        public AdminTest()
        {
            // Mock the dependencies
            _mockAuthService = new Mock<IAuthentication>();
            _mockPlantDeptService = new Mock<ILocation>();
            _mockSupplierService = new Mock<Isupplier>();
            _mockEquipmentService = new Mock<IEquipment>();
            _mockEmailService = new Mock<IEMailService>();

            // Inject mocks into the controller
            //_controller = new AdminCOntroller(_mockAuthService.Object, _mockPlantDeptService.Object, _mockSupplierService.Object, _mockEquipmentService.Object, _mockEmailService.Object);
        }



        //Users management Tests










        //Equipment Tests
          //getAllEquipments
        
        [Fact]
        public async Task GetAllEquipments()
        {
            // Arrange
            var expectedEquipments = new List<EquipmentDTO>
            {
                new EquipmentDTO { EquipementSN= 1, EquipName = "PC", supplierrid = "Supp1" },
                new EquipmentDTO { EquipementSN = 2, EquipName = "Clavier", supplierrid = "Supp2" }
            };
            _mockEquipmentService.Setup(service => service.GetEquipments()).ReturnsAsync(expectedEquipments);

            // Act
            var result = await _controller.GetAllEquipemnts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualEquipments = Assert.IsType<List<EquipmentDTO>>(okResult.Value);
            Assert.Equal(expectedEquipments.Count, actualEquipments.Count);
            Assert.Equal(expectedEquipments[0].EquipementSN, actualEquipments[0].EquipementSN);
            Assert.Equal(expectedEquipments[0].EquipName, actualEquipments[0].EquipName);
            Assert.Equal(expectedEquipments[0].supplierrid, actualEquipments[0].supplierrid);
        }
        //Addequipment

            [Fact]
            public async Task AddNewEquipment_ReturnsOkResult_WithEquipment()
           {
            // Arrange
            var equipment = new Equipment { EquipementSN = 1, EquipName = "PC", supplierrid = "1" };
            _mockEquipmentService.Setup(service => service.AddEquipment(equipment)).ReturnsAsync(new OkObjectResult(equipment));

            // Act
            var result = await _controller.AddNewEquipment(equipment);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Equipment>(okResult.Value);
            Assert.Equal(equipment.EquipementSN, returnValue.EquipementSN);
             }

        //updateEquipment
              [Fact]
            public async Task UpdateEquipement_ReturnsOkResult_WithUpdatedEquipment()
            {
            // Arrange
            var equipment = new Equipment { EquipementSN = 1, EquipName = "PC", supplierrid = "2" };
            _mockEquipmentService.Setup(service => service.UpdateEquipemnt(equipment.EquipementSN, equipment)).ReturnsAsync(new OkObjectResult(equipment));

            // Act
            var result = await _controller.UpdateEquipement(equipment.EquipementSN, equipment);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Equipment>(okResult.Value);
            Assert.Equal(equipment.EquipementSN, returnValue.EquipementSN);
             }
        //DeleteEquipment
              [Fact]
        public async Task DeleteEquipment_ReturnsNoContentResult()
        {
            // Arrange
            var equipmentId = 1;
            _mockEquipmentService.Setup(service => service.RemoveEquipment(equipmentId)).ReturnsAsync(new NoContentResult());

            // Act
            var result = await _controller.DeleteEquipment(equipmentId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        //GetNumberOf equipemnts
        [Fact]
        public async Task GetNumberofEquipements_ReturnsOkResult_WithEquipmentCount()
        {
            // Arrange
            var equipmentCount = 10;
            _mockEquipmentService.Setup(service => service.GetEquipmentCount()).ReturnsAsync(equipmentCount);

            // Act
            var result = await _controller.GetNumberofEquipements();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<int>(okResult.Value);
            Assert.Equal(equipmentCount, returnValue);
        }

        //GetAllEquipemntNameWithEquipmentNames
        [Fact]
        public async Task GetAllEquipemntName_ReturnsOkResult_WithEquipmentNames()
        {
            // Arrange
            var equipmentNames = new List<dynamic>
           {
              new { EquipementSN = 1, EquipName = "PC" },
              new { EquipementSN = 2, EquipName = "Clavier" }
           };
            _mockEquipmentService.Setup(service => service.GetEquipemntInfoAsync()).ReturnsAsync(equipmentNames);

            // Act
            var result = await _controller.GetAllEquipemntName();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<List<dynamic>>(okResult.Value);
            Assert.Equal(equipmentNames.Count, returnValue.Count);
            Assert.Equal(equipmentNames[0].EquipementSN, returnValue[0].EquipementSN);
            Assert.Equal(equipmentNames[0].EquipName, returnValue[0].EquipName);
        }

        //Location (Plant-Depart) Management Tests
         //Add location with multiple plant and departments
        [Fact]
        public async Task AddPlant_ReturnsOkResult_WithNewLocation()
        {
            // Arrange
            var newLocation = new LocationDTO
            {
                LocationId = 1,
                LocationName = "New Location",
                Plants = new List<PlantDto>
                {
                    new PlantDto { PlantNumber = 1, plant_name = "ICT" },
                    new PlantDto { PlantNumber = 2, plant_name = "Auto" }
                },
                Departments = new List<DepartmentDTO>
                {
                    new DepartmentDTO { DeptId = 1, DepartmentName = "It" },
                    new DepartmentDTO { DeptId = 2, DepartmentName = "Finance" }
                }
            };
            _mockPlantDeptService.Setup(service => service.CreateLocation(newLocation)).ReturnsAsync(new OkObjectResult(newLocation));

            // Act
            var result = await _controller.AddPlant(newLocation);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<LocationDTO>(okResult.Value);
            Assert.Equal(newLocation.LocationId, returnValue.LocationId);
            Assert.Equal(newLocation.LocationName, returnValue.LocationName);

            Assert.Equal(newLocation.Plants.Count, returnValue.Plants.Count);
            for (int i = 0; i < newLocation.Plants.Count; i++)
            {
                Assert.Equal(newLocation.Plants[i].PlantNumber, returnValue.Plants[i].PlantNumber);
                Assert.Equal(newLocation.Plants[i].plant_name, returnValue.Plants[i].plant_name);
            }

            Assert.Equal(newLocation.Departments.Count, returnValue.Departments.Count);
            for (int i = 0; i < newLocation.Departments.Count; i++)
            {
                Assert.Equal(newLocation.Departments[i].DeptId, returnValue.Departments[i].DeptId);
                Assert.Equal(newLocation.Departments[i].DepartmentName, returnValue.Departments[i].DepartmentName);
            }
        }
        //delete location
        [Fact]
        public async Task DeleteLocation_ReturnsNoContentResult()
        {
            // Arrange
            var locationId = 1;
            _mockPlantDeptService.Setup(service => service.DeleteLocation(locationId)).ReturnsAsync(new NoContentResult());

            // Act
            var result = await _controller.DeleteLocation(locationId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        //add plant to location
        [Fact]
        public async Task AddPlantToLocation_ReturnsOkResult_WithNewPlant()
        {
            // Arrange
            var locationId = 1;
            var plantDto = new PlantDto { PlantNumber = 1, plant_name = "New Plant" };
            _mockPlantDeptService.Setup(service => service.AddPlantToLocation(locationId, plantDto)).ReturnsAsync(new OkObjectResult(plantDto));

            // Act
            var result = await _controller.AddPlantToLocation(locationId, plantDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<PlantDto>(okResult.Value);
            Assert.Equal(plantDto.PlantNumber, returnValue.PlantNumber);
            Assert.Equal(plantDto.plant_name, returnValue.plant_name);
        }

        //update plant of exixting location
        [Fact]
        public async Task UpdatePlantLocation_ReturnsOkResult_WithUpdatedPlant()
        {
            // Arrange
            var locationId = 1;
            var plantId = 1;
            var plantDto = new PlantDto { PlantNumber = plantId, plant_name = "Updated Plant" };
            _mockPlantDeptService.Setup(service => service.UpdatePlantOfLocation(locationId, plantId, plantDto)).ReturnsAsync(new OkObjectResult(plantDto));

            // Act
            var result = await _controller.UpdatePlantLocation(locationId, plantId, plantDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<PlantDto>(okResult.Value);
            Assert.Equal(plantDto.PlantNumber, returnValue.PlantNumber);
            Assert.Equal(plantDto.plant_name, returnValue.plant_name);
            
        }
        //delete plant of exicting location
        [Fact]
        public async Task DeletePlantofLocation_ReturnsNoContentResult()
        {
            // Arrange
            var locationId = 1;
            var plantId = 1;
            _mockPlantDeptService.Setup(service => service.DeletePlantofLocation(locationId, plantId)).ReturnsAsync(new NoContentResult());

            // Act
            var result = await _controller.DeletePlantofLocation(locationId, plantId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        
        //Add departement to location
        [Fact]
        public async Task AdddepartementToLocation_ReturnsOkResult_WithNewDepartment()
        {
            // Arrange
            var locationId = 1;
            var departmentDto = new DepartmentDTO { DeptId = 1, DepartmentName = "New Department" };
            _mockPlantDeptService.Setup(service => service.AddDepartementToLocation(locationId, departmentDto)).ReturnsAsync(new OkObjectResult(departmentDto));

            // Act
            var result = await _controller.AdddepartementToLocation(locationId, departmentDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<DepartmentDTO>(okResult.Value);
            Assert.Equal(departmentDto.DeptId, returnValue.DeptId);
            Assert.Equal(departmentDto.DepartmentName, returnValue.DepartmentName);
        }

        //update departement of existing location
        [Fact]
        public async Task UpdateDepartementLocation_ReturnsOkResult_WithUpdatedDepartment()
        {
            // Arrange
            var locationId = 1;
            var deptId = 1;
            var departmentDto = new DepartmentDTO {DeptId = deptId, DepartmentName = "Updated Department" };
            _mockPlantDeptService.Setup(service => service.UpdateDepartementOfLocation(locationId, deptId, departmentDto)).ReturnsAsync(new OkObjectResult(departmentDto));

            // Act
            var result = await _controller.UpdateDepartementLocation(locationId, deptId, departmentDto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<DepartmentDTO>(okResult.Value);
            Assert.Equal(departmentDto.DeptId, returnValue.DeptId);
            Assert.Equal(departmentDto.DepartmentName, returnValue.DepartmentName);
        }


        //Getplants
        [Fact]
        public async Task GetAllPlants()
        {
            // Arrange
            var plants = new List<PlantDto>
            {
                new PlantDto { PlantNumber = 1, plant_name = "Plant 1" },
                new PlantDto { PlantNumber = 2, plant_name = "Plant 2" }
            };
            _mockPlantDeptService.Setup(service => service.GetPlants()).ReturnsAsync(plants);

            // Act
            var result = await _controller.GetAllPlants();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<List<PlantDto>>(okResult.Value);
            Assert.Equal(plants.Count, returnValue.Count);
            Assert.Equal(plants[0].PlantNumber, returnValue[0].PlantNumber);
            Assert.Equal(plants[0].plant_name, returnValue[0].plant_name);
        }

        //Get all deopartements
        [Fact]
        public async Task GetAllDepartments()
        {
            // Arrange
            var departments = new List<DepartmentDTO>
            {
                new DepartmentDTO { DeptId = 1, DepartmentName = "Department 1" },
                new DepartmentDTO { DeptId = 2, DepartmentName = "Department 2" }
            };
            _mockPlantDeptService.Setup(service => service.GetDepartments()).ReturnsAsync(departments);

            // Act
            var result = await _controller.GetAllDepartments();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnValue = Assert.IsType<List<DepartmentDTO>>(okResult.Value);
            Assert.Equal(departments.Count, returnValue.Count);
            Assert.Equal(departments[0].DeptId, returnValue[0].DeptId);
            Assert.Equal(departments[0].DepartmentName, returnValue[0].DepartmentName);
        }


        //Supplier Tests
        //get All suppliers
        [Fact]
        public async Task GetAllSuppliers_ReturnsOkResult_WithListOfSuppliers()
        {
            // Arrange
            var expectedSuppliers = new List<Supplier>
            {
                new Supplier { SuplierId = "1", suuplier_name = "Supplier1", address = "Address1", email = "supplier1@example.com" },
                new Supplier { SuplierId = "2", suuplier_name = "Supplier2", address = "Address2", email = "supplier2@example.com" }
            };
            _mockSupplierService.Setup(service => service.GetSuppliers()).ReturnsAsync(expectedSuppliers);

            // Act
            var result = await _controller.GetAllSuppliers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualSuppliers = Assert.IsType<List<Supplier>>(okResult.Value);
            Assert.Equal(expectedSuppliers.Count, actualSuppliers.Count);
            Assert.Equal(expectedSuppliers[0].SuplierId, actualSuppliers[0].SuplierId);
            Assert.Equal(expectedSuppliers[0].suuplier_name, actualSuppliers[0].suuplier_name);
            Assert.Equal(expectedSuppliers[0].address, actualSuppliers[0].address);
            Assert.Equal(expectedSuppliers[0].email, actualSuppliers[0].email);
        }
        //add supplier
        [Fact]
        public async Task CreateSupplier_ReturnsOkResult_WithCreatedSupplier()
        {
            // Arrange
            var newSupplier = new Supplier
            {
                SuplierId = "1",
                suuplier_name = "New Supplier",
                address = "New Address",
                email = "newsupplier@example.com"
            };

            _mockSupplierService.Setup(service => service.AddSuplier(It.IsAny<Supplier>())).ReturnsAsync(new OkObjectResult(newSupplier));

            // Act
            var result = await _controller.CreateSupplier(newSupplier);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualSupplier = Assert.IsType<Supplier>(okResult.Value);
            Assert.Equal(newSupplier.SuplierId, actualSupplier.SuplierId);
            Assert.Equal(newSupplier.suuplier_name, actualSupplier.suuplier_name);
            Assert.Equal(newSupplier.address, actualSupplier.address);
            Assert.Equal(newSupplier.email, actualSupplier.email);
        }

        //delete supplier

        [Fact]

        public async Task DeleteSupplier()
        {
            // Arrange
            var supplierId = "6";
            _mockSupplierService.Setup(service => service.DeleteSuplier(It.IsAny<string>()))
                                .ReturnsAsync(new OkObjectResult(supplierId));

            // Act
            var result = await _controller.DeleteSupplier(supplierId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualSupplierId = Assert.IsType<string>(okResult.Value);
            Assert.Equal(supplierId, actualSupplierId);
        }

        //update supplier
        [Fact]
        public async Task UpdateSupplier_ReturnsOkResult_WithUpdatedSupplier()
        {
            // Arrange
            var supplierId = "1";
            var updatedSupplier = new Supplier
            {
                suuplier_name = "Updated Supplier",
                address = "123 Updated Address",
                email = "updated@example.com"
            };

            _mockSupplierService.Setup(service => service.UpdateUser(supplierId, updatedSupplier))
                                .ReturnsAsync(new OkObjectResult(updatedSupplier));

            // Act
            var result = await _controller.UpdateSupplier(supplierId, updatedSupplier);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSupplier = Assert.IsType<Supplier>(okResult.Value);
            Assert.Equal(updatedSupplier.suuplier_name, returnedSupplier.suuplier_name);
            Assert.Equal(updatedSupplier.address, returnedSupplier.address);
            Assert.Equal(updatedSupplier.email, returnedSupplier.email);
        }




        // get the number of suppliers
        [Fact]
        public async Task GetNumberofSuppliers_ReturnsOkResult_WithSupplierCount()
        {
            // Arrange
            var expectedCount = 5;
            _mockSupplierService.Setup(service => service.GetSuppliersCount()).ReturnsAsync(expectedCount);

            // Act
            var result = await _controller.GetNumberofSupplires();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualCount = Assert.IsType<int>(okResult.Value);
            Assert.Equal(expectedCount, actualCount);
            // Output the result to the console
            Console.WriteLine($"Number of suppliers: {actualCount}");
        }

    }
}
