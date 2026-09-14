using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Mappings
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