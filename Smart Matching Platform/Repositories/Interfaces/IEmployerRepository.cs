using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Repositories
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