using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Skill;
using SmartRecruitmentMatchingPlatform.API.Repositories;

namespace SmartRecruitmentMatchingPlatform.API.Services
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