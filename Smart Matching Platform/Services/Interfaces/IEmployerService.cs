using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public interface IEmployerService
    {
        Task<EmployerProfileResponseDto?> GetProfileAsync(int userId);

        Task<EmployerProfileResponseDto> CreateProfileAsync(
            int userId,
            UpdateEmployerProfileRequestDto request);

        Task<EmployerProfileResponseDto?> UpdateProfileAsync(
            int userId,
            UpdateEmployerProfileRequestDto request);
    }
}