using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Skill;
using SmartRecruitmentMatchingPlatform.API.Services;


namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/vacancies/skills")]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();

            return Ok(skills);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);

            if (skill == null)
                return NotFound(new
                {
                    message = "Skill not found."
                });

            return Ok(skill);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,JobSeeker")]
        public async Task<IActionResult> CreateSkill(CreateSkillDto dto)
        {
            var skill = await _skillService.CreateSkillAsync(dto);

            return Ok(skill);
        }
    }
}