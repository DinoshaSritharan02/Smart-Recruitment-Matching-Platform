using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Matching;

namespace SmartRecruitmentMatchingPlatform.API.Repositories;

public interface IMatchingRepository
{
    Task<List<MatchResultDto>> GetMatchesAsync(Guid userId);
    Task<List<RankedApplicantResponseDto>> GetRankedApplicantsAsync(int vacancyId);
}