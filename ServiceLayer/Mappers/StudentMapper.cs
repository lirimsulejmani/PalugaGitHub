using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DatabaseLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer.Mappers
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<School, SchoolDto>().ReverseMap();
            CreateMap<StudyCourse, StudyCourseDto>().ReverseMap();
            CreateMap<EducationDegree, EducationDegreeDto>().ReverseMap();

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.EducationDegreeId, opts => opts.MapFrom(src => src.EducationDegree.Id))
                .ForMember(dest => dest.SchoolId, opts => opts.MapFrom(src => src.School.Id));

            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.EducationDegree, opts => opts.ResolveUsing(src => new EducationDegree() { Id = src.EducationDegreeId }))
                .ForMember(dest => dest.School, opts => opts.ResolveUsing(src => new School() { Id = src.SchoolId }));
                //.AfterMap((src, dest) => dest.EducationDegree = new EducationDegree(){ Id = src.EducationDegree })
                //.AfterMap((src, dest) => dest.School = new School(){ Id = src.School } )
                //.AfterMap((src, dest) => dest.StudyCourse = new StudyCourse() { Id = src.StudyCourse });
            CreateMap<UpdateProfileDto, Student>();
        }
    }
}
