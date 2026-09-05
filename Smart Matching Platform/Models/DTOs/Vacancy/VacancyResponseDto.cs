namespace Smart_Matching_Platform.Models.DTOs.Vacancy
{
    public class VacancyResponseDto
    {
        public int Id { get; set; }

        public int EmployerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int RequiredExperienceYears { get; set; }

        public string? EducationRequirement { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<int> SkillIds { get; set; } = new();
    }
}