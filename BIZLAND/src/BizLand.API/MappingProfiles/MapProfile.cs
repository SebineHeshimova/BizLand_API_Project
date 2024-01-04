using AutoMapper;
using BizLand.Business.DTOs.EmployeeDTOs;
using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Core.Entity;

namespace BizLand.API.MappingProfiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Profession, CreateProfessionDTO>().ReverseMap();
            CreateMap<Profession, UpdateProfessionDTO>().ReverseMap();
            CreateMap<Profession, GetProfessionDTO>().ReverseMap();

            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>().ReverseMap();

            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetFeatureDTO>().ReverseMap();
        }
    }
}
