using Microsoft.AspNetCore.Http;

namespace SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

public class UploadCvDto
{
    public IFormFile File { get; set; } = null!;
}