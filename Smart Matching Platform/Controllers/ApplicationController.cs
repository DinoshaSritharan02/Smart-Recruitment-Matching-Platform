using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using System.Security.Claims;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/applications")]
    
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("vacancy/{vacancyId:int}/apply")]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> ApplyForVacancy(int vacancyId)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var applied = await _applicationService.ApplyForVacancyAsync(
                userId.Value,
                vacancyId);

            if (!applied)
            {
                return BadRequest(new
                {
                    message = "Unable to apply. The vacancy may not exist, may be closed, or you have already applied."
                });
            }

            return Ok(new
            {
                message = "Application submitted successfully."
            });
        }

        [HttpGet("vacancy/{vacancyId:int}/ranked")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetRankedApplicants(int vacancyId)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var applicants = await _applicationService.GetRankedApplicantsAsync(
    userId.Value,
    vacancyId);
            return Ok(applicants);
        }
        [HttpPut("{applicationId:int}/status")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateStatus(
    int applicationId,
    [FromBody] UpdateApplicationStatusRequestDto request)
        {
            var userId = GetUserId();

            if (userId == null)
                return Unauthorized();

            var updated = await _applicationService.UpdateStatusAsync(
                userId.Value,
                applicationId,
                request.Status);

            if (!updated)
                return NotFound(new
                {
                    message = "Application not found or you do not own this application."
                });

            return Ok(new
            {
                message = "Application status updated successfully."
            });
        }

        private Guid? GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.TryParse(userIdClaim, out var userId))
                return userId;

            return null;
        }
    }
}