using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Helpers
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            //plants,Departement mapper
            CreateMap<Location, LocationDTO>()
             .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.LocationDepartments.Select(ld => ld.Department)))
             .ForMember(dest => dest.Plants, opt => opt.MapFrom(src => src.LocationPlants.Select(lp => lp.Plant)));
            CreateMap<Department, DepartmentDTO>()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.TeNum))
                ;
            CreateMap<Plant, PlantDto>()
            .ForMember(dest => dest.Approver_name, opt => opt.MapFrom(src => src.Approver.TeNum))
                ;
            //role mapper
            CreateMap<IdentityRole, RoleDTO>();

            // Add mapping from ApplicationUser to UserDetailsDTO
            CreateMap<ApplicationUser, UserDetailsDTO>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore())
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
            .ForMember(dest => dest.Backupaprover_Name, opt => opt.MapFrom(src => src.Backupaprover.TeNum))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => string.Join(", ", src.Department.LocationDepartments.Select(ld => ld.Location.LocationName))))
            .ForMember(dest => dest.plant_name, opt => opt.MapFrom(src => string.Join(", ", src.Department.LocationDepartments.SelectMany(ld => ld.Location.LocationPlants.Select(lp => lp.Plant.plant_name)))))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
