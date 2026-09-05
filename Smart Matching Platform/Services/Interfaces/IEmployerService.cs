using Smart_Matching_Platform.Models.DTOs.Employer;

namespace Smart_Matching_Platform.Services
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