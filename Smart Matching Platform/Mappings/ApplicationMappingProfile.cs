using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Application, ApplicationResponseDto>();
        }
    }
}