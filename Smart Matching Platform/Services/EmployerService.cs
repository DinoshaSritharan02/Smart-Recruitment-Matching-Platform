using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<EmployerProfileResponseDto?> GetProfileAsync(Guid userId)
        {
            var employer = await _employerRepository.GetByUserIdAsync(userId);

            if (employer == null)
                return null;

            return MapToResponseDto(employer);
        }

        public async Task<EmployerProfileResponseDto> CreateProfileAsync(
            Guid userId,
            UpdateEmployerProfileRequestDto request)
        {
            var existingEmployer = await _employerRepository.GetByUserIdAsync(userId);

            if (existingEmployer != null)
                throw new InvalidOperationException(
                    "Employer profile already exists for this user.");

            var employer = new Employer
            {
                UserId = userId,
                CompanyName = request.CompanyName,
                CompanyDescription = request.CompanyDescription,
                Industry = request.Industry,
                CompanyLocation = request.CompanyLocation,
                Website = request.Website,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _employerRepository.AddAsync(employer);

            return MapToResponseDto(employer);
        }

        public async Task<EmployerProfileResponseDto?> UpdateProfileAsync(
            Guid userId,
            UpdateEmployerProfileRequestDto request)
        {
            var employer = await _employerRepository.GetByUserIdAsync(userId);

            if (employer == null)
                return null;

            employer.CompanyName = request.CompanyName;
            employer.CompanyDescription = request.CompanyDescription;
            employer.Industry = request.Industry;
            employer.CompanyLocation = request.CompanyLocation;
            employer.Website = request.Website;
            employer.UpdatedAt = DateTime.UtcNow;

            await _employerRepository.UpdateAsync(employer);

            return MapToResponseDto(employer);
        }

        private static EmployerProfileResponseDto MapToResponseDto(
            Employer employer)
        {
            return new EmployerProfileResponseDto
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                CompanyDescription = employer.CompanyDescription,
                Industry = employer.Industry,
                CompanyLocation = employer.CompanyLocation,
                Website = employer.Website,
                CreatedAt = employer.CreatedAt,
                UpdatedAt = employer.UpdatedAt
            };
        }
    }
}