using AutoMapper;
using CensusData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CensusData.GetsApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<GenderResult, DTO.GenderResult>();
            CreateMap<Gender, DTO.Gender>();

            CreateMap<EducationLevelResult, DTO.EducationLevelResult>();
            CreateMap<EducationLevel, DTO.EducationLevel>();
        }
    }
}
