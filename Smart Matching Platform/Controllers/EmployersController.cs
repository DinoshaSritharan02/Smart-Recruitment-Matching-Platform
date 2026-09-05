using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;
using SmartRecruitmentMatchingPlatform.API.Services;
using System.Security.Claims;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/employer/profile")]
    [Authorize(Roles = "Employer")]
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployersController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var profile = await _employerService.GetProfileAsync(userId.Value);

            if (profile == null)
                return NotFound(new
                {
                    message = "Employer profile not found."
                });

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(
            [FromBody] UpdateEmployerProfileRequestDto request)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var profile = await _employerService.CreateProfileAsync(
                userId.Value,
                request);

            return CreatedAtAction(
                nameof(GetProfile),
                null,
                profile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(
            [FromBody] UpdateEmployerProfileRequestDto request)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var profile = await _employerService.UpdateProfileAsync(
                userId.Value,
                request);

            if (profile == null)
                return NotFound(new
                {
                    message = "Employer profile not found."
                });

            return Ok(profile);
        }

        private int? GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userIdClaim, out var userId))
                return userId;

            return null;
        }
    }
}