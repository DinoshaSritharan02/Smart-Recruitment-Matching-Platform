using Smart_Matching_Platform.Enums;
using Smart_Matching_Platform.Models.DTOs.Application;

namespace Smart_Matching_Platform.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<bool> UpdateStatusAsync(
            int employerId,
            int applicationId,
            ApplicationStatus status);

        Task<List<ApplicationResponseDto>> GetApplicantsByVacancyAsync(
            int employerId,
            int vacancyId);

        Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(
            int employerId,
            int vacancyId);
    }
}