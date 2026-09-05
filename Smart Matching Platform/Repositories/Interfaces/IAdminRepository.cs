using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

public interface IAdminRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(int id);

    Task<int> GetTotalUsersAsync();

    Task<int> GetTotalJobSeekersAsync();

    Task<int> GetTotalEmployersAsync();

    Task<int> GetTotalVacanciesAsync();

    Task<int> GetTotalApplicationsAsync();

    Task SaveChangesAsync();
}