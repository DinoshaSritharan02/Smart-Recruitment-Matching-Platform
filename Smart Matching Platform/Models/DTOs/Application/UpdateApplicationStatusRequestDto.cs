using SmartRecruitmentMatchingPlatform.API.Enums;

namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application
{
    public class UpdateApplicationStatusRequestDto
    {
        public ApplicationStatus Status { get; set; }
    }
}