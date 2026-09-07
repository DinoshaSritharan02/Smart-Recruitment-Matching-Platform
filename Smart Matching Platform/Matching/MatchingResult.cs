namespace SmartRecruitmentMatchingPlatform.API.Matching
{
    public class MatchingResult
    {
        public int Score { get; set; }

        public int SkillScore { get; set; }

        public int ExperienceScore { get; set; }

        public int EducationScore { get; set; }

        public int LocationScore { get; set; }

        public List<string> MatchingSkills { get; set; } = new();

        public List<string> MissingSkills { get; set; } = new();
    }
}