using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using Smart_Matching_Platform.Repositories;

namespace Smart_Matching_Platform.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<VacancyResponseDto?> GetByIdAsync(int id)
        {
            var vacancy = await _vacancyRepository.GetByIdAsync(id);

            if (vacancy == null)
                return null;

            return MapToResponseDto(vacancy);
        }

        public async Task<List<VacancyListItemDto>> GetMyVacanciesAsync(
            int employerId)
        {
            var vacancies =
                await _vacancyRepository.GetByEmployerIdAsync(employerId);

            return vacancies.Select(MapToListItemDto).ToList();
        }

        public async Task<List<VacancyListItemDto>> SearchAsync(
            VacancySearchRequestDto request)
        {
            var vacancies = await _vacancyRepository.SearchAsync(
                request.Keyword,
                request.Location,
                request.MinExperienceYears,
                request.MaxExperienceYears,
                request.SkillId);

            return vacancies.Select(MapToListItemDto).ToList();
        }

        public async Task<VacancyResponseDto> CreateAsync(
            int employerId,
            CreateVacancyRequestDto request)
        {
            var vacancy = new Vacancy
            {
                EmployerId = employerId,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                RequiredExperienceYears = request.RequiredExperienceYears,
                EducationRequirement = request.EducationRequirement,
                Status = VacancyStatus.Open,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            foreach (var skillId in request.SkillIds.Distinct())
            {
                vacancy.VacancySkills.Add(new VacancySkill
                {
                    SkillId = skillId
                });
            }

            await _vacancyRepository.AddAsync(vacancy);

            return MapToResponseDto(vacancy);
        }

        public async Task<VacancyResponseDto?> UpdateAsync(
            int employerId,
            int vacancyId,
            UpdateVacancyRequestDto request)
        {
            var vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

            if (vacancy == null)
                return null;

            if (vacancy.EmployerId != employerId)
                return null;

            vacancy.Title = request.Title;
            vacancy.Description = request.Description;
            vacancy.Location = request.Location;
            vacancy.RequiredExperienceYears =
                request.RequiredExperienceYears;
            vacancy.EducationRequirement =
                request.EducationRequirement;

            vacancy.Status = request.IsClosed
                ? VacancyStatus.Closed
                : VacancyStatus.Open;

            vacancy.UpdatedAt = DateTime.UtcNow;

            vacancy.VacancySkills.Clear();

            foreach (var skillId in request.SkillIds.Distinct())
            {
                vacancy.VacancySkills.Add(new VacancySkill
                {
                    VacancyId = vacancy.Id,
                    SkillId = skillId
                });
            }

            await _vacancyRepository.UpdateAsync(vacancy);

            return MapToResponseDto(vacancy);
        }

        private static VacancyResponseDto MapToResponseDto(
            Vacancy vacancy)
        {
            return new VacancyResponseDto
            {
                Id = vacancy.Id,
                EmployerId = vacancy.EmployerId,
                Title = vacancy.Title,
                Description = vacancy.Description,
                Location = vacancy.Location,
                RequiredExperienceYears =
                    vacancy.RequiredExperienceYears,
                EducationRequirement =
                    vacancy.EducationRequirement,
                Status = vacancy.Status.ToString(),
                CreatedAt = vacancy.CreatedAt,
                UpdatedAt = vacancy.UpdatedAt,
                SkillIds = vacancy.VacancySkills
                    .Select(vs => vs.SkillId)
                    .ToList()
            };
        }

        private static VacancyListItemDto MapToListItemDto(
            Vacancy vacancy)
        {
            return new VacancyListItemDto
            {
                Id = vacancy.Id,
                Title = vacancy.Title,
                Location = vacancy.Location,
                RequiredExperienceYears =
                    vacancy.RequiredExperienceYears,
                EducationRequirement =
                    vacancy.EducationRequirement,
                Status = vacancy.Status.ToString(),
                CreatedAt = vacancy.CreatedAt
            };
        }
    }
}