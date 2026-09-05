using Smart_Matching_Platform.Models.Entities;

namespace Smart_Matching_Platform.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();

        Task<Skill?> GetByIdAsync(int id);

        Task<Skill?> GetByNameAsync(string name);
    }
}