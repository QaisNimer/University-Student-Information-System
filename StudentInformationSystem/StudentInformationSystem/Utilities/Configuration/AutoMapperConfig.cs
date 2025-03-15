using AutoMapper;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Utilities.Dto;

namespace StudentInformationSystem.Utilities.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisteredCourses, RegisterCourseDto>();
            CreateMap<RegisteredCourses, RegisterCourseDto>().ReverseMap();
        }
    }
}
