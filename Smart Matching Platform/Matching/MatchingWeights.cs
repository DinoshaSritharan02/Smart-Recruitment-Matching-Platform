namespace SmartRecruitmentMatchingPlatform.API.Matching
{
    public static class MatchingWeights
    {
        public const int Skills = 45;
        public const int Experience = 30;
        public const int Education = 15;
        public const int Location = 10;

        public const int Total = Skills + Experience + Education + Location;
    }
}