namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy
{
    public class VacancySearchRequestDto
    {
        public string? Keyword { get; set; }

        public string? Location { get; set; }

        public int? MinExperienceYears { get; set; }

        public int? MaxExperienceYears { get; set; }

        public int? SkillId { get; set; }
    }
}