using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application?> GetByIdAsync(int id);

        Task<List<Application>> GetByVacancyIdAsync(int vacancyId);

        Task<List<Application>> GetByJobSeekerProfileIdAsync(Guid jobSeekerProfileId);

        Task AddAsync(Application application);

        Task UpdateAsync(Application application);

        Task<bool> ExistsAsync(Guid jobSeekerProfileId, int vacancyId);
    }
}