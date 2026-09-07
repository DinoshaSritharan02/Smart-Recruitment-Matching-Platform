using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy;
using SmartRecruitmentMatchingPlatform.API.Services;
using System.Security.Claims;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/vacancies")]
    [Authorize]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;
        private readonly IEmployerService _employerService;

        public VacanciesController(
            IVacancyService vacancyService,
            IEmployerService employerService)
        {
            _vacancyService = vacancyService;
            _employerService = employerService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vacancy = await _vacancyService.GetByIdAsync(id);

            if (vacancy == null)
                return NotFound(new
                {
                    message = "Vacancy not found."
                });

            return Ok(vacancy);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] VacancySearchRequestDto request)
        {
            var vacancies = await _vacancyService.SearchAsync(request);

            return Ok(vacancies);
        }

        [HttpGet("employer/mine")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetMyVacancies()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var employer = await _employerService.GetProfileAsync(userId.Value);

            if (employer == null)
                return NotFound(new
                {
                    message = "Employer profile not found."
                });

            var vacancies =
                await _vacancyService.GetMyVacanciesAsync(employer.Id);

            return Ok(vacancies);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create(
            [FromBody] CreateVacancyRequestDto request)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var employer = await _employerService.GetProfileAsync(userId.Value);

            if (employer == null)
                return NotFound(new
                {
                    message = "Employer profile not found."
                });

            var vacancy = await _vacancyService.CreateAsync(
                employer.Id,
                request);

            return Ok(vacancy);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateVacancyRequestDto request)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var employer = await _employerService.GetProfileAsync(userId.Value);

            if (employer == null)
                return NotFound(new
                {
                    message = "Employer profile not found."
                });

            var vacancy = await _vacancyService.UpdateAsync(
                employer.Id,
                id,
                request);

            if (vacancy == null)
                return NotFound(new
                {
                    message = "Vacancy not found or you do not own this vacancy."
                });

            return Ok(vacancy);
        }

        private Guid? GetUserId()
        {
            var userIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.TryParse(userIdClaim, out var userId))
                return userId;

            return null;
        }
    }
}