using Smart_Matching_Platform.Enums;
namespace Smart_Matching_Platform.Models.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }

        public int EmployerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int RequiredExperienceYears { get; set; }

        public string? EducationRequirement { get; set; }

        public VacancyStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<VacancySkill> VacancySkills { get; set; }
            = new List<VacancySkill>();
    }
}