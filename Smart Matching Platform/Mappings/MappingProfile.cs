using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Authentication
        CreateMap<RegisterJobSeekerRequestDto, User>();
        CreateMap<RegisterEmployerRequestDto, User>();
        CreateMap<User, UserSummaryDto>();

        // Job Seeker Profile
        CreateMap<JobSeekerProfile, JobSeekerProfileDto>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.Skills,
                opt => opt.MapFrom(src =>
                    src.JobSeekerSkills.Select(x => x.Skill.Name)));

        CreateMap<UpdateJobSeekerProfileDto, JobSeekerProfile>();

        // Education
        CreateMap<Education, EducationDto>();
        CreateMap<CreateEducationDto, Education>();
        CreateMap<UpdateEducationDto, Education>();

        // Experience
        CreateMap<Experience, ExperienceDto>();
        CreateMap<CreateExperienceDto, Experience>();
        CreateMap<UpdateExperienceDto, Experience>();

        // CV
        CreateMap<CvMetadata, CvMetadataDto>();

        // Skills
        CreateMap<AddSkillDto, JobSeekerSkill>();
    }
}