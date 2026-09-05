using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public interface IJobSeekerService
{
    Task<JobSeekerProfileDto?> GetProfileAsync(Guid userId);

    Task UpdateProfileAsync(Guid userId, UpdateJobSeekerProfileDto dto);

    Task AddSkillAsync(Guid userId, AddSkillDto dto);

    Task RemoveSkillAsync(Guid userId, string skillName);

    Task AddEducationAsync(Guid userId, CreateEducationDto dto);

    Task UpdateEducationAsync(Guid educationId, UpdateEducationDto dto);

    Task DeleteEducationAsync(Guid educationId);

    Task AddExperienceAsync(Guid userId, CreateExperienceDto dto);

    Task UpdateExperienceAsync(Guid experienceId, UpdateExperienceDto dto);

    Task DeleteExperienceAsync(Guid experienceId);

    Task<CvMetadataDto?> GetCvMetadataAsync(Guid userId);
    Task UploadCvAsync(Guid userId, UploadCvDto dto);

    Task<(FileStream Stream, string ContentType, string FileName)> DownloadCvAsync(Guid userId);
}