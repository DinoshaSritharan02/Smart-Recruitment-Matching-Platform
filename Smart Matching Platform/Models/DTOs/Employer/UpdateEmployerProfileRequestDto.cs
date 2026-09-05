namespace Smart_Matching_Platform.Models.DTOs.Employer
{
    public class UpdateEmployerProfileRequestDto
    {
        public string CompanyName { get; set; } = string.Empty;

        public string? CompanyDescription { get; set; }

        public string? Industry { get; set; }

        public string? CompanyLocation { get; set; }

        public string? Website { get; set; }
    }
}