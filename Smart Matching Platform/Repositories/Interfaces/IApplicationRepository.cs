using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application?> GetByIdAsync(int id);

        Task<List<Application>> GetByVacancyIdAsync(int vacancyId);

        Task<List<Application>> GetByJobSeekerIdAsync(int jobSeekerId);

        Task AddAsync(Application application);

        Task UpdateAsync(Application application);

        Task<bool> ExistsAsync(int jobSeekerId, int vacancyId);
    }
}