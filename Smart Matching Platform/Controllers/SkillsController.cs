using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Matching_Platform.Services;
using SmartRecruitmentMatchingPlatform.API.Services;

namespace Smart_Matching_Platform.Controllers
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
    }
}