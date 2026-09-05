namespace Smart_Matching_Platform.Models.DTOs.Employer
{
    public class EmployerProfileResponseDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string? CompanyDescription { get; set; }

        public string? Industry { get; set; }

        public string? CompanyLocation { get; set; }

        public string? Website { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}