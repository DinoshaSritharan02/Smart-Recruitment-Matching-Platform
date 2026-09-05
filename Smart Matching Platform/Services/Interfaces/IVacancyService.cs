using Smart_Matching_Platform.Models.DTOs.Vacancy;

namespace Smart_Matching_Platform.Services
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