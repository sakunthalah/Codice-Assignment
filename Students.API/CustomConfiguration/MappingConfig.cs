using AutoMapper;
using DataAccess.Entities;
using Model.Dtos;
using Model.Request;
using Model.Response;

namespace Students.API.CustomConfiguration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

                config.CreateMap<ClassRequestDto, ClassDto>()
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                 .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());
                config.CreateMap<ClassDto, Class>();
                config.CreateMap<Class, ClassDto>();
                config.CreateMap<ClassDto, ClassResponseDto>();

                config.CreateMap<StudentRequestDto, StudentDto>()
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<StudentDto, StudentResponseDto>();

                config.CreateMap<SubjectRequestDto, SubjectDto>()
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
             .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());
                config.CreateMap<SubjectDto, Subject>();
                config.CreateMap<Subject, SubjectDto>();
                config.CreateMap<SubjectDto, SubjectResponseDto>();

                config.CreateMap<StudentsSubjectRequestDto, StudentsSubjectDto>();
                config.CreateMap<StudentsSubjectDto, StudentsSubject>();
                config.CreateMap<StudentsSubject, StudentsSubjectDto>();
                config.CreateMap<StudentsSubjectDto, StudentsSubjectResponseDto>();

            });

            return mappingConfig;
        }
    }
}
