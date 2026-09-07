using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Services;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MatchingController : ControllerBase
    {
        private readonly IMatchingService _matchingService;

        public MatchingController(IMatchingService matchingService)
        {
            _matchingService = matchingService;
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetMatches(Guid userId)
        {
            var matches = await _matchingService.GetMatchesAsync(userId);

            return Ok(matches);
        }
        [HttpGet("ranked-applicants/{vacancyId:int}")]
        public async Task<IActionResult> GetRankedApplicants(int vacancyId)
        {
            var rankedApplicants = await _matchingService.GetRankedApplicantsAsync(vacancyId);

            return Ok(rankedApplicants);
        }
    }
}