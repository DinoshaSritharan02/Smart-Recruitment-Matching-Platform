using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Matching;
using SmartRecruitmentMatchingPlatform.API.Repositories;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public class MatchingService : IMatchingService
    {
        private readonly IMatchingRepository _matchingRepository;

        public MatchingService(IMatchingRepository matchingRepository)
        {
            _matchingRepository = matchingRepository;
        }

        public async Task<List<MatchResultDto>> GetMatchesAsync(Guid userId)
        {
            return await _matchingRepository.GetMatchesAsync(userId);
        }
        public async Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(int vacancyId)
        {
            return await _matchingRepository.GetRankedApplicantsAsync(vacancyId);
        }
    }
}