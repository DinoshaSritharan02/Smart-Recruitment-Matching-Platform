using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterJobSeekerAsync(RegisterJobSeekerRequestDto request);

    Task<AuthResponseDto> RegisterEmployerAsync(RegisterEmployerRequestDto request);

    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
}