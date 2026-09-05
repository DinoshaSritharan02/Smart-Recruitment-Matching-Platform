namespace SmartRecruitmentMatchingPlatform.API.Models.Entities;

public class CvMetadata
{
    public Guid Id { get; set; }

    public Guid JobSeekerProfileId { get; set; }

    public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

    public string OriginalFileName { get; set; } = string.Empty;

    public string StoredFileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}