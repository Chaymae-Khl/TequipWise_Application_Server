using AutoMapper;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Helpers
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            //plants,Departement mapper
            CreateMap<Plant, PlantDto>();
            CreateMap<Department, DepartmentDTO>();

            // Add mapping from ApplicationUser to UserDetailsDTO
            CreateMap<ApplicationUser, UserDetailsDTO>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())  // We'll handle roles separately
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Department.Plant.location))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
