using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TequipWiseServer.Controllers;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace MyApp.Tests
{
    public class SupplierTest
    {

        private readonly Mock<IAuthentication> _mockAuthService;
        private readonly Mock<ILocation> _mockPlantDeptService;
        private readonly Mock<Isupplier> _mockSupplierService;
        private readonly Mock<IEquipment> _mockEquipmentService;

        private readonly AdminCOntroller _controller;

        public SupplierTest()
        {
            // Mock the dependencies
            _mockAuthService = new Mock<IAuthentication>();
            _mockPlantDeptService = new Mock<ILocation>();
            _mockSupplierService = new Mock<Isupplier>();
            _mockEquipmentService = new Mock<IEquipment>();

            // Inject mocks into the controller
            _controller = new AdminCOntroller(_mockAuthService.Object, _mockPlantDeptService.Object, _mockSupplierService.Object, _mockEquipmentService.Object);
        }


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
