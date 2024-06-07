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
            CreateMap<Location, LocationDTO>()
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.LocationDepartments != null ? src.LocationDepartments.Select(ld => ld.Department) : new List<Department>()))
            .ForMember(dest => dest.Plants, opt => opt.MapFrom(src => src.LocationPlants != null ? src.LocationPlants.Select(lp => lp.Plant) : new List<Plant>()));

            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.TeNum : null));

            CreateMap<Plant, PlantDto>()
                .ForMember(dest => dest.Approver_name, opt => opt.MapFrom(src => src.Approver != null ? src.Approver.TeNum : null));

            CreateMap<IdentityRole, RoleDTO>();

            CreateMap<UserEquipmentRequest, EquipementRequestDTO>();
            CreateMap<ApplicationUser, UserDetailsDTO>()
                           .ForMember(dest => dest.Roles, opt => opt.Ignore())
                           .ForMember(dest => dest.Backupaprover_Name, opt => opt.MapFrom(src => src.Backupaprover != null ? src.Backupaprover.TeNum : null))
                           .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.TeNum : null))
                           .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.LocationName : null))
                           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
                           .ForMember(dest => dest.plant_name, opt => opt.MapFrom(src => src.Plant != null ? src.Plant.plant_name : null))
                           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Equipment, EquipmentDTO>()
      .ForMember(dest => dest.supplierName, opt => opt.MapFrom(src => src.supplier != null ? src.supplier.suuplier_name : null));
        }
    }
}
