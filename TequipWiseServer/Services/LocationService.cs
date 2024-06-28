using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Models;
using System.Numerics;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;

namespace TequipWiseServer.Services
{
    public class LocationService : ILocation
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper; // Inject IMapper

        public LocationService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> AddPlant(Plant newPlant)
        {
            _dbContext.Plants.Add(newPlant);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(new Response { Status = "Success", Message = "Plant Added successfully!" });

        }

        public async Task<IActionResult> CreateLocation(LocationDTO locationDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var newLocation = new Location
                {
                    LocationName = locationDto.LocationName,
                };

                _dbContext.Location.Add(newLocation);
                await _dbContext.SaveChangesAsync();

                if (locationDto.Departments != null && locationDto.Departments.Any())
                {
                    var departments = new List<Department>();
                    foreach (var deptDto in locationDto.Departments)
                    {
                        var department = new Department
                        {
                            DepartmentName = deptDto.DepartmentName,
                            Status = deptDto.Status,
                            ManagerId = deptDto.ManagerId
                        };
                        departments.Add(department);
                    }

                    _dbContext.Departments.AddRange(departments);
                    await _dbContext.SaveChangesAsync();

                    var locationDepartments = departments.Select(dept => new LocationDepartment
                    {
                        LocationId = newLocation.LocationId,
                        DepartmentId = dept.DeptId,
                        ManagerId = dept.ManagerId
                    }).ToList();

                    _dbContext.LocationDepartments.AddRange(locationDepartments);
                }

                if (locationDto.Plants != null && locationDto.Plants.Any())
                {
                    var plants = new List<Plant>();
                    foreach (var plantDto in locationDto.Plants)
                    {
                        var plant = new Plant
                        {
                            plant_name = plantDto.plant_name,
                            SapNumber=plantDto.SapNumber,
                            ApproverId = plantDto.ApproverId,
                            ITApproverId=plantDto.ITApproverId
                        };
                        plants.Add(plant);
                    }

                    _dbContext.Plants.AddRange(plants);
                    await _dbContext.SaveChangesAsync();

                    var locationPlants = plants.Select(plant => new LocationPlant
                    {
                        LocationId = newLocation.LocationId,
                        PlantId = plant.PlantNumber
                    }).ToList();

                    _dbContext.LocationPlants.AddRange(locationPlants);
                }

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Location and associated entities added successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Retrieve the location entity
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                // Remove associated departments
                var locationDepartments = await _dbContext.LocationDepartments.Where(ld => ld.LocationId == locationId).ToListAsync();
                _dbContext.LocationDepartments.RemoveRange(locationDepartments);

                // Remove associated plants
                var locationPlants = await _dbContext.LocationPlants.Where(lp => lp.LocationId == locationId).ToListAsync();
                _dbContext.LocationPlants.RemoveRange(locationPlants);

                // Remove the location itself
                _dbContext.Location.Remove(location);

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Location and its associated entities removed successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        public async Task<IEnumerable<PlantDto>> GetPlants()
        {
            var plants = await _dbContext.Plants.ToListAsync();

            // Use AutoMapper to map Plant entities to PlantDto objects
            var plantlist = _mapper.Map<List<PlantDto>>(plants);

            return plantlist;
        }
        public async Task<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            var depts = await _dbContext.Departments.ToListAsync();

            // Use AutoMapper to map Plant entities to PlantDto objects
            var deptlist = _mapper.Map<List<DepartmentDTO>>(depts);

            return deptlist;
        }


        //Location with palnt and department
        public async Task<IActionResult> AddPlantToLocation(int locationId, PlantDto plantDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Find the existing location
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                // Create the new plant entity
                var newPlant = new Plant
                {
                    plant_name = plantDto.plant_name,
                    SapNumber=plantDto.SapNumber,
                    ApproverId = plantDto.ApproverId,
                    ITApproverId = plantDto.ITApproverId

                };

                _dbContext.Plants.Add(newPlant);
                await _dbContext.SaveChangesAsync();

                // Create the LocationPlant relationship
                var locationPlant = new LocationPlant
                {
                    LocationId = location.LocationId,
                    PlantId = newPlant.PlantNumber
                };

                _dbContext.LocationPlants.Add(locationPlant);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Plant added to location successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> UpdatePlantOfLocation(int locationId, int plantId, PlantDto plantDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Find the existing location
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                // Find the existing plant
                var plant = await _dbContext.Plants.FindAsync(plantId);
                if (plant == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Plant not found" });
                }

                // Check if the plant is associated with the given location
                var locationPlant = await _dbContext.LocationPlants
                    .FirstOrDefaultAsync(lp => lp.LocationId == locationId && lp.PlantId == plantId);
                if (locationPlant == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "The plant is not associated with the given location" });
                }

                // Update the plant entity
                plant.plant_name = plantDto.plant_name;
                plant.SapNumber = plantDto.SapNumber;
                plant.ApproverId = plantDto.ApproverId;
                plant.ITApproverId = plantDto.ITApproverId;

                _dbContext.Plants.Update(plant);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Plant updated successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> DeletePlantofLocation(int locationId, int plantId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                var plant = await _dbContext.Plants.FindAsync(plantId);
                if (plant == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Plant not found" });
                }

                var locationPlant = await _dbContext.LocationPlants
                    .FirstOrDefaultAsync(lp => lp.LocationId == locationId && lp.PlantId == plantId);
                if (locationPlant == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "The plant is not associated with the given location" });
                }

                _dbContext.LocationPlants.Remove(locationPlant);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Plant removed from location successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
    }

        public async Task<IActionResult> AddDepartementToLocation(int locationId, DepartmentDTO departmentDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Find the existing location
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                // Create the new plant entity
                var newDepartement = new Department
                {
                    DepartmentName = departmentDto.DepartmentName,
                    Status = departmentDto.Status,
                    ManagerId = departmentDto.ManagerId
                };

                _dbContext.Departments.Add(newDepartement);
                await _dbContext.SaveChangesAsync();

                // Create the LocationPlant relationship
                var locationDepartement = new LocationDepartment
                {
                    LocationId = location.LocationId,
                    DepartmentId = newDepartement.DeptId
                };

                _dbContext.LocationDepartments.Add(locationDepartement);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Departement  added to location successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        public async Task<IActionResult> UpdateDepartementOfLocation(int locationId, int deptId, DepartmentDTO departmentDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                // Find the existing location
                var location = await _dbContext.Location.FindAsync(locationId);
                if (location == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Location not found" });
                }

                // Find the existing plant
                var department = await _dbContext.Departments.FindAsync(deptId);
                if (department == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "Departement not found" });
                }

                // Check if the plant is associated with the given location
                var locationDept = await _dbContext.LocationDepartments
                    .FirstOrDefaultAsync(ld => ld.LocationId == locationId && ld.DepartmentId == deptId);
                if (locationDept == null)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "The Departement is not associated with the given location" });
                }

                // Update the plant entity
                department.DepartmentName = departmentDto.DepartmentName;
                department.Status = departmentDto.Status;
                department.ManagerId = departmentDto.ManagerId;

                _dbContext.Departments.Update(department);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return new OkObjectResult(new Response { Status = "Success", Message = "Departemnt updated successfully!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new BadRequestObjectResult(new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
