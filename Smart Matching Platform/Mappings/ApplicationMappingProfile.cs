using AutoMapper;
using Smart_Matching_Platform.Models.DTOs.Application;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Application, ApplicationResponseDto>();
        }
    }
}