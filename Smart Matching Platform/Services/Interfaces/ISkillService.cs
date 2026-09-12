using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Skill;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public interface ISkillService
    {
        Task<List<SkillResponseDto>> GetAllSkillsAsync();

        Task<SkillResponseDto?> GetSkillByIdAsync(int id);

        Task<SkillResponseDto> CreateSkillAsync(CreateSkillDto dto);
    }
}