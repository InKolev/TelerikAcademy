using AutoMapper;
using StudentSystem.Models;
using StudentSystem.Services.Models;

namespace StudentSystem.Services
{
    public static class ObjectMappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Student, StudentResponseModel>()
                .ForMember(
                    dest => dest.ID,
                    src => src.MapFrom(obj => obj.ID));

            Mapper.CreateMap<StudentResponseModel, Student>()
                .ForMember(
                    dest => dest.ID,
                    src => src.MapFrom(obj => obj.ID));

            Mapper.CreateMap<Course, CourseResponseModel>()
                .ForMember(
                    dest => dest.ID,
                    src => src.MapFrom(obj => obj.ID));

            Mapper.CreateMap<CourseResponseModel, Course>();

            Mapper.CreateMap<Homework, HomeworkResponseModel>();

            Mapper.CreateMap<Test, TestResponseModel>();
        }
    }
}