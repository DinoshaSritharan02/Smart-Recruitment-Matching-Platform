using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;

namespace SmartRecruitmentMatchingPlatform.API.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<bool> UpdateStatusAsync(
    Guid userId,
    int applicationId,
    ApplicationStatus status);


        Task<List<MyApplicationDto>> GetMyApplicationsAsync(Guid userId);

        Task<bool> ApplyForVacancyAsync(Guid userId, int vacancyId);

        Task<List<ApplicationResponseDto>> GetApplicantsByVacancyAsync(
            Guid userId,
            int vacancyId);

        Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(
            Guid userId,
            int vacancyId);

        
    }
}