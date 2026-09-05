using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace Smart_Matching_Platform.Repositories
{
    public interface IVacancyRepository
    {
        Task<Vacancy?> GetByIdAsync(int id);

        Task<List<Vacancy>> GetByEmployerIdAsync(int employerId);

        Task<List<Vacancy>> SearchAsync(
            string? keyword,
            string? location,
            int? minExperienceYears,
            int? maxExperienceYears,
            int? skillId);

        Task AddAsync(Vacancy vacancy);

        Task UpdateAsync(Vacancy vacancy);
    }
}