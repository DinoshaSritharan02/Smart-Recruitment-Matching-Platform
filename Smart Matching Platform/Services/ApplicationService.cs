using Smart_Matching_Platform.Enums;
using Smart_Matching_Platform.Models.DTOs.Application;
using Smart_Matching_Platform.Repositories;
using Smart_Matching_Platform.Repositories.Interfaces;
using Smart_Matching_Platform.Services.Interfaces;

namespace Smart_Matching_Platform.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IVacancyRepository _vacancyRepository;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IVacancyRepository vacancyRepository)
        {
            _applicationRepository = applicationRepository;
            _vacancyRepository = vacancyRepository;
        }

        public async Task<bool> UpdateStatusAsync(
            int employerId,
            int applicationId,
            ApplicationStatus status)
        {
            var application =
                await _applicationRepository.GetByIdAsync(applicationId);

            if (application == null)
                return false;

            if (application.Vacancy.EmployerId != employerId)
                return false;

            application.Status = status;
            application.UpdatedAt = DateTime.UtcNow;

            await _applicationRepository.UpdateAsync(application);

            return true;
        }

        public async Task<List<ApplicationResponseDto>> GetApplicantsByVacancyAsync(
            int employerId,
            int vacancyId)
        {
            var vacancy =
                await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null || vacancy.EmployerId != employerId)
                return new List<ApplicationResponseDto>();

            var applications =
                await _applicationRepository.GetByVacancyIdAsync(vacancyId);

            return applications.Select(application => new ApplicationResponseDto
            {
                Id = application.Id,
                JobSeekerId = application.JobSeekerId,
                VacancyId = application.VacancyId,
                Status = application.Status,
                MatchScore = application.MatchScore,
                AppliedAt = application.AppliedAt,
                UpdatedAt = application.UpdatedAt
            }).ToList();
        }

        public async Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(
            int employerId,
            int vacancyId)
        {
            var vacancy =
                await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null || vacancy.EmployerId != employerId)
                return new List<RankedApplicantResponseDto>();

            var applications =
                await _applicationRepository.GetByVacancyIdAsync(vacancyId);

            return applications
                .OrderByDescending(a => a.MatchScore)
                .Select(a => new RankedApplicantResponseDto
                {
                    ApplicationId = a.Id,
                    JobSeekerId = a.JobSeekerId,
                    MatchScore = a.MatchScore,
                    Status = a.Status.ToString(),
                    AppliedAt = a.AppliedAt
                })
                .ToList();
        }
    }
}