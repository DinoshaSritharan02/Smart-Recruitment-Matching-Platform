using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.DTOs.ContactRequests;
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

        public ContactRequestsController(
            IContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequests()
        {
            var jobSeekerProfileId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var requests = await _contactRequestService.GetRequestsAsync(jobSeekerProfileId);

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