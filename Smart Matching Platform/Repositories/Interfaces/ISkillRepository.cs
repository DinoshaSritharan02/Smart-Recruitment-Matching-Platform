using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();

        Task<Skill?> GetByIdAsync(int id);

        Task<Skill?> GetByNameAsync(string name);

        Task AddAsync(Skill skill);

        Task SaveChangesAsync();
    }
}