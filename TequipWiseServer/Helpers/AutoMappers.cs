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
                .ForMember(dest => dest.ITApprover_name, opt => opt.MapFrom(src => src.ItApprover != null ? src.ItApprover.TeNum : null));

            CreateMap<IdentityRole, RoleDTO>();

            CreateMap<EquipmentRequest, EquipementRequestDTO>()
            .ForMember(dest => dest.NmaeOfUser, opt => opt.MapFrom(src => src.User != null ? src.User.TeNum : null))
            .ForMember(dest => dest.SapNumOfUser, opt => opt.MapFrom(src => src.User.SapNumber != null ? src.User.SapNumber.SapNum : null));
            

            CreateMap<SubEquipmentRequest, EquipementSUBrequestDTO>()
            .ForMember(dest => dest.ItApproverName, opt => opt.MapFrom(src => src.IT != null ? src.IT.TeNum : null))
            .ForMember(dest => dest.ControllerName, opt => opt.MapFrom(src => src.Controller != null ? src.Controller.TeNum : null))
            .ForMember(dest => dest.departementManagerName, opt => opt.MapFrom(src => src.DeparManag != null ? src.DeparManag.TeNum : null))
            .ForMember(dest => dest.EquipementName, opt => opt.MapFrom(src => src.Equipment != null ? src.Equipment.EquipName : null))
                .ForMember(dest => dest.supplierName, opt => opt.MapFrom(src => src.supplier.suuplier_name));
            
            CreateMap<SubEquipmentRequest, AssignedAssetDTO>()
            .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Equipment != null ? src.Equipment.EquipName : null))
                ;

            CreateMap<PhoneRequest, PhoneRequestDTO>()
           .ForMember(dest => dest.NmaeOfUser, opt => opt.MapFrom(src => src.User != null ? src.User.TeNum : null))
           .ForMember(dest => dest.departementManagerName, opt => opt.MapFrom(src => src.DeparManag != null ? src.DeparManag.TeNum : null))
           .ForMember(dest => dest.ItApproverName, opt => opt.MapFrom(src => src.IT != null ? src.IT.TeNum : null))
           .ForMember(dest => dest.HRApproverName, opt => opt.MapFrom(src => src.HR != null ? src.HR.TeNum : null));



            CreateMap<SapNumber, SapNumberDto>()
                .ForMember(dest => dest.Controller_name, opt => opt.MapFrom(src => src.Controller != null ? src.Controller.TeNum : null)).ReverseMap();

            CreateMap<Equipment, EquipmentDTO>()
                .ForMember(dest => dest.supplierName, opt => opt.MapFrom(src => src.supplier.suuplier_name));
            CreateMap<ApplicationUser, UserDetailsDTO>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Subordinates, opt => opt.MapFrom(src => src.Subordinates))
                .ForMember(dest => dest.Backupaprover_Name, opt => opt.MapFrom(src => src.Backupaprover != null ? src.Backupaprover.TeNum : null))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.TeNum : null))
                .ForMember(dest => dest.ManagerEmail, opt => opt.MapFrom(src => src.Department != null ? src.Department.Manager.Email : null))
                .ForMember(dest => dest.ItApproverEmail, opt => opt.MapFrom(src => src.Plant != null ? src.Plant.ItApprover.Email : null))
                .ForMember(dest => dest.ApproverEmail, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.Email : null))
                .ForMember(dest => dest.ManagerBackupApproverEmail, opt => opt.MapFrom(src => src.Department != null && src.Department.Manager.Backupaprover != null ? src.Department.Manager.Backupaprover.Email : null))
                .ForMember(dest => dest.ManagerBackupApproverActive, opt => opt.MapFrom(src => src.Department != null && src.Department.Manager != null ? src.Department.Manager.backupActive : null))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.LocationName : null))
                .ForMember(dest => dest.SapNumb, opt => opt.MapFrom(src => src.SapNumber != null ? src.SapNumber.SapNum : null))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : null))
                .ForMember(dest => dest.plant_name, opt => opt.MapFrom(src => src.Plant != null ? src.Plant.plant_name : null))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ApplicationUser, SubordinateDTO>();
           

        }
    }
}