namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

public class CvMetadataDto
{
    public Guid Id { get; set; }

    public string OriginalFileName { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public DateTime UploadedAt { get; set; }
}