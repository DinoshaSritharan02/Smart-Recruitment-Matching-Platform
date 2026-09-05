using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;
using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Mappings;

public class AdminMappingProfile : Profile
{
    public AdminMappingProfile()
    {
        CreateMap<Notification, NotificationDto>();

        CreateMap<CreateNotificationDto, Notification>();

        CreateMap<ContactRequest, ContactRequestDto>()
            .ForMember(
                dest => dest.EmployerName,
                opt => opt.MapFrom(src => src.Employer.CompanyName));

        CreateMap<User, UserSummaryDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.FirstName));
    }
}