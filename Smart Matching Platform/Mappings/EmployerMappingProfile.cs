using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Mappings
{
    public class EmployerMappingProfile : Profile
    {
        public EmployerMappingProfile()
        {
            CreateMap<Employer, EmployerProfileResponseDto>();

            CreateMap<UpdateEmployerProfileRequestDto, Employer>();
        }
    }
}