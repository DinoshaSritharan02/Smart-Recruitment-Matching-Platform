namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy
{
    public class VacancyListItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Location { get; set; }

        public int RequiredExperienceYears { get; set; }

        public string? EducationRequirement { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}