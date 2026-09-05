using Smart_Matching_Platform.Models.DTOs.Skill;

namespace Smart_Matching_Platform.Services
{
    public interface ISkillService
    {
        Task<List<SkillResponseDto>> GetAllSkillsAsync();

        Task<SkillResponseDto?> GetSkillByIdAsync(int id);
    }
}