using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public interface IEmployerService
    {
        Task<EmployerProfileResponseDto?> GetProfileAsync(Guid userId);

        Task<EmployerProfileResponseDto> CreateProfileAsync(
            Guid userId,
            UpdateEmployerProfileRequestDto request);

        Task<EmployerProfileResponseDto?> UpdateProfileAsync(
            Guid userId,
            UpdateEmployerProfileRequestDto request);
    }
}