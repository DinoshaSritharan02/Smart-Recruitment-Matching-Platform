using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy;

namespace SmartRecruitmentMatchingPlatform.API.Services
{
    public interface IVacancyService
    {
        Task<VacancyResponseDto?> GetByIdAsync(int id);

        Task<List<VacancyListItemDto>> GetMyVacanciesAsync(
            int employerId);

        Task<List<VacancyListItemDto>> SearchAsync(
            VacancySearchRequestDto request);

        Task<VacancyResponseDto> CreateAsync(
            int employerId,
            CreateVacancyRequestDto request);

        Task<VacancyResponseDto?> UpdateAsync(
            int employerId,
            int vacancyId,
            UpdateVacancyRequestDto request);
    }
}