using AutoMapper;
using Smart_Matching_Platform.Models.DTOs.Employer;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Mappings
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