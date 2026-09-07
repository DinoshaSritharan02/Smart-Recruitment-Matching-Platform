using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
using SmartRecruitmentMatchingPlatform.API.Repositories;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;
using System.Security.Claims;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [Route("api/contactrequests")]
    [ApiController]
    [Authorize]
    public class ContactRequestsController : ControllerBase
    {
        private readonly IContactRequestService _contactRequestService;
        private readonly IJobSeekerRepository _jobSeekerRepository;

        public ContactRequestsController(
            IContactRequestService contactRequestService,
            IJobSeekerRepository jobSeekerRepository)
        {
            _contactRequestService = contactRequestService;
            _jobSeekerRepository = jobSeekerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

            if (profile == null)
                return NotFound("Job seeker profile not found.");

            var requests = await _contactRequestService.GetRequestsAsync(profile.Id);

            return Ok(requests);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            UpdateContactRequestStatusDto dto)
        {
            await _contactRequestService.UpdateStatusAsync(id, dto);

            return NoContent();
        }
    }
}