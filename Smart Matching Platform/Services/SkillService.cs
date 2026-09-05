using Smart_Matching_Platform.Models.DTOs.Skill;
using Smart_Matching_Platform.Repositories;

namespace Smart_Matching_Platform.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillResponseDto>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync();

            return skills.Select(skill => new SkillResponseDto
            {
                Id = skill.Id,
                Name = skill.Name
            }).ToList();
        }

        public async Task<SkillResponseDto?> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if (skill == null)
                return null;

            return new SkillResponseDto
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }
    }
}