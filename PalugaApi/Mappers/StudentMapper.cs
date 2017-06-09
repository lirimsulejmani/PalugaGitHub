using System;
using AutoMapper;
using PalugaApi.Models;
using ServiceLayer.DTO;

namespace PalugaApi.Mappers
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<UpdateProfileRequest, UpdateProfileDto>();
            CreateMap<StudentDto, StudentViewModel>();
            CreateMap<StudentDto, UpdateProfileRequest>()
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(dest => dest.EducationDegreeId, opt => opt.MapFrom(src => src.EducationDegreeId));
        }
    }
}
