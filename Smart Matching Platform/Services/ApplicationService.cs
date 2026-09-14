using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IEmployerRepository _employerRepository;

        private readonly IJobSeekerRepository _jobSeekerRepository;

        public ApplicationService(
     IApplicationRepository applicationRepository,
     IVacancyRepository vacancyRepository,
     IEmployerRepository employerRepository,
     IJobSeekerRepository jobSeekerRepository)
        {
            _applicationRepository = applicationRepository;
            _vacancyRepository = vacancyRepository;
            _employerRepository = employerRepository;
            _jobSeekerRepository = jobSeekerRepository;
        }

        public async Task<bool> UpdateStatusAsync(
            Guid userId,
            int applicationId,
            ApplicationStatus status)
        {
            var employer = await _employerRepository.GetByUserIdAsync(userId);

            if (employer == null)
                return false;

            var application = await _applicationRepository.GetByIdAsync(applicationId);

            if (application == null)
                return false;

            if (application.Vacancy.EmployerId != employer.Id)
                return false;

            application.Status = status;
            application.UpdatedAt = DateTime.UtcNow;

            await _applicationRepository.UpdateAsync(application);

            return true;
        }

        public async Task<List<ApplicationResponseDto>> GetApplicantsByVacancyAsync(
            Guid userId,
            int vacancyId)
        {
            var employer = await _employerRepository.GetByUserIdAsync(userId);

            if (employer == null)
                return new List<ApplicationResponseDto>();

            var vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null || vacancy.EmployerId != employer.Id)
                return new List<ApplicationResponseDto>();

            var applications = await _applicationRepository.GetByVacancyIdAsync(vacancyId);

            return applications.Select(application => new ApplicationResponseDto
            {
                Id = application.Id,
                JobSeekerProfileId = application.JobSeekerProfileId,
                VacancyId = application.VacancyId,
                Status = application.Status,
                MatchScore = application.MatchScore,
                AppliedAt = application.AppliedAt,
                UpdatedAt = application.UpdatedAt
            }).ToList();
        }

        public async Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(
            Guid userId,
            int vacancyId)
        {
            var employer = await _employerRepository.GetByUserIdAsync(userId);

            if (employer == null)
                return new List<RankedApplicantResponseDto>();

            var vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null || vacancy.EmployerId != employer.Id)
                return new List<RankedApplicantResponseDto>();

            var applications = await _applicationRepository.GetByVacancyIdAsync(vacancyId);

            return applications
                .OrderByDescending(a => a.MatchScore)
                .Select(a => new RankedApplicantResponseDto
                {
                    ApplicationId = a.Id,
                    JobSeekerProfileId = a.JobSeekerProfileId,
                    MatchScore = a.MatchScore,
                    Status = a.Status.ToString(),
                    AppliedAt = a.AppliedAt
                })
                .ToList();
        }
        public async Task<bool> ApplyForVacancyAsync(Guid userId, int vacancyId)
        {
            var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

            if (profile == null)
                return false;

            var vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null)
                return false;

            if (vacancy.Status != VacancyStatus.Open)
                return false;

            var alreadyApplied = await _applicationRepository.ExistsAsync(
                profile.Id,
                vacancyId);

            if (alreadyApplied)
                return false;

            var application = new Application
            {
                JobSeekerProfileId = profile.Id,
                VacancyId = vacancyId,
                Status = ApplicationStatus.Applied,
                AppliedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                MatchScore = null
            };

            await _applicationRepository.AddAsync(application);

            return true;
        }
        
        public async Task<List<MyApplicationDto>> GetMyApplicationsAsync(Guid userId)
        {
            var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

            if (profile == null)
                return new List<MyApplicationDto>();

            var applications = await _applicationRepository
                .GetByJobSeekerProfileIdAsync(profile.Id);

            return applications.Select(a => new MyApplicationDto
            {
                Id = a.Id,
                VacancyId = a.VacancyId,
                JobTitle = a.Vacancy.Title,
                CompanyName = a.Vacancy.Employer.CompanyName,
                Location = a.Vacancy.Location,
                Status = a.Status.ToString(),
                MatchScore = a.MatchScore,
                AppliedAt = a.AppliedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList();
        }
    }
}