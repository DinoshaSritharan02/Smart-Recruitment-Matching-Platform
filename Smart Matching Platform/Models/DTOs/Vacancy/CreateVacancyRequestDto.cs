namespace Smart_Matching_Platform.Models.DTOs.Vacancy
{
    public class CreateVacancyRequestDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int RequiredExperienceYears { get; set; }

        public string? EducationRequirement { get; set; }

        public List<int> SkillIds { get; set; } = new();
    }
}