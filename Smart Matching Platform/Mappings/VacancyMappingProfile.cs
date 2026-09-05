using AutoMapper;
using Smart_Matching_Platform.Models.DTOs.Vacancy;
using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Mappings
{
    public class VacancyMappingProfile : Profile
    {
        public VacancyMappingProfile()
        {
            CreateMap<Vacancy, VacancyResponseDto>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(
                    dest => dest.SkillIds,
                    opt => opt.MapFrom(src =>
                        src.VacancySkills.Select(vs => vs.SkillId)));

            CreateMap<Vacancy, VacancyListItemDto>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}