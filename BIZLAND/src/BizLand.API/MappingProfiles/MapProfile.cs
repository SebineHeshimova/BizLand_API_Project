﻿using AutoMapper;
using BizLand.Business.DTOs.CategoryDTOs;
using BizLand.Business.DTOs.EmployeeDTOs;
using BizLand.Business.DTOs.FeatureDTOs;
using BizLand.Business.DTOs.PortfolioDTOs;
using BizLand.Business.DTOs.ProfessionDTOs;
using BizLand.Business.DTOs.SliderDTOs;
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

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();

            CreateMap<Portfolio, CreatePortfolioDTO>().ReverseMap();
            CreateMap<Portfolio, UpdatePortfolioDTO>().ReverseMap();
            CreateMap<Portfolio, GetPortfolioDTO>().ReverseMap();

            CreateMap<Slider, CreateSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();
            CreateMap<Slider, GetSliderDTO>().ReverseMap();
        }
    }
}
