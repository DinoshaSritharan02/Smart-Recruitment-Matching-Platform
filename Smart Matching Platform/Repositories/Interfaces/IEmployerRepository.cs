using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public interface IEmployerRepository
    {
        Task<Employer?> GetByIdAsync(int id);

        Task<Employer?> GetByUserIdAsync(int userId);

        Task AddAsync(Employer employer);

        Task UpdateAsync(Employer employer);

        Task<bool> ExistsByUserIdAsync(int userId);
    }
}