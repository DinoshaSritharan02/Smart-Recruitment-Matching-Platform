using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Skill;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
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
        public async Task<SkillResponseDto> CreateSkillAsync(CreateSkillDto dto)
        {
            var existing = await _skillRepository.GetByNameAsync(dto.Name);

            if (existing != null)
            {
                return new SkillResponseDto
                {
                    Id = existing.Id,
                    Name = existing.Name
                };
            }

            var skill = new Skill
            {
                Name = dto.Name.Trim()
            };

            await _skillRepository.AddAsync(skill);

            await _skillRepository.SaveChangesAsync();

            return new SkillResponseDto
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }
    }
}