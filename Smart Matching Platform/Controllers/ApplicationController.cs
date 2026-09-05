using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Matching_Platform.Models.DTOs.Application;
using Smart_Matching_Platform.Services.Interfaces;
using System.Security.Claims;

namespace Smart_Matching_Platform.Controllers
{
    [ApiController]
    [Route("api/applications")]
    [Authorize(Roles = "Employer")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("vacancy/{vacancyId:int}/ranked")]
        public async Task<IActionResult> GetRankedApplicants(int vacancyId)
        {
            var employerId = GetEmployerId();

            if (employerId == null)
                return Unauthorized();

            var applicants = await _applicationService
                .GetRankedApplicantsAsync(employerId.Value, vacancyId);

            return Ok(applicants);
        }

        [HttpPut("{applicationId:int}/status")]
        public async Task<IActionResult> UpdateStatus(
            int applicationId,
            [FromBody] UpdateApplicationStatusRequestDto request)
        {
            var employerId = GetEmployerId();

            if (employerId == null)
                return Unauthorized();

            var updated = await _applicationService.UpdateStatusAsync(
                employerId.Value,
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

        private int? GetEmployerId()
        {
            var employerIdClaim =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(employerIdClaim, out var employerId))
                return employerId;

            return null;
        }
    }
}