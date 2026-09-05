using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public class JobSeekerService : IJobSeekerService
{
    private readonly IJobSeekerRepository _jobSeekerRepository;
    private readonly ICvMetadataRepository _cvMetadataRepository;
    private readonly ICvStorageService _cvStorageService;
    private readonly IMapper _mapper;

    private readonly ISkillRepository _skillRepository;

    public JobSeekerService(
    IJobSeekerRepository jobSeekerRepository,
    ICvMetadataRepository cvMetadataRepository,
    ICvStorageService cvStorageService,
    ISkillRepository skillRepository,
    IMapper mapper)
    {
        _jobSeekerRepository = jobSeekerRepository;
        _cvMetadataRepository = cvMetadataRepository;
        _cvStorageService = cvStorageService;
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<JobSeekerProfileDto?> GetProfileAsync(Guid userId)
    {
        var profile = await _jobSeekerRepository.GetProfileWithDetailsAsync(userId);

        if (profile == null)
            return null;

        return _mapper.Map<JobSeekerProfileDto>(profile);
    }

    public async Task UpdateProfileAsync(Guid userId, UpdateJobSeekerProfileDto dto)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        _mapper.Map(dto, profile);

        await _jobSeekerRepository.UpdateProfileAsync(profile);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task AddSkillAsync(Guid userId, AddSkillDto dto)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var skill = await _skillRepository.GetByIdAsync(dto.SkillId);

        if (skill == null)
            throw new Exception("Skill not found.");

        var existingSkill = await _jobSeekerRepository.GetSkillAsync(profile.Id, dto.SkillId);

        if (existingSkill != null)
            throw new Exception("Skill already exists.");

        var jobSeekerSkill = new JobSeekerSkill
        {
            Id = Guid.NewGuid(),
            JobSeekerProfileId = profile.Id,
            SkillId = dto.SkillId
        };

        await _jobSeekerRepository.AddSkillAsync(jobSeekerSkill);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task RemoveSkillAsync(Guid userId, int skillId)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var skill = await _jobSeekerRepository.GetSkillAsync(profile.Id, skillId);

        if (skill == null)
            throw new Exception("Skill not found.");

        await _jobSeekerRepository.RemoveSkillAsync(skill);
        await _jobSeekerRepository.SaveChangesAsync();
    }
    public async Task AddEducationAsync(Guid userId, CreateEducationDto dto)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var education = _mapper.Map<Education>(dto);

        education.Id = Guid.NewGuid();
        education.JobSeekerProfileId = profile.Id;

        await _jobSeekerRepository.AddEducationAsync(education);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task UpdateEducationAsync(Guid educationId, UpdateEducationDto dto)
    {
        var education = await _jobSeekerRepository.GetEducationAsync(educationId);

        if (education == null)
            throw new Exception("Education not found.");

        _mapper.Map(dto, education);

        await _jobSeekerRepository.UpdateEducationAsync(education);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task DeleteEducationAsync(Guid educationId)
    {
        var education = await _jobSeekerRepository.GetEducationAsync(educationId);

        if (education == null)
            throw new Exception("Education not found.");

        await _jobSeekerRepository.DeleteEducationAsync(education);
        await _jobSeekerRepository.SaveChangesAsync();
    }
    public async Task AddExperienceAsync(Guid userId, CreateExperienceDto dto)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var experience = _mapper.Map<Experience>(dto);

        experience.Id = Guid.NewGuid();
        experience.JobSeekerProfileId = profile.Id;

        await _jobSeekerRepository.AddExperienceAsync(experience);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task UpdateExperienceAsync(Guid experienceId, UpdateExperienceDto dto)
    {
        var experience = await _jobSeekerRepository.GetExperienceAsync(experienceId);

        if (experience == null)
            throw new Exception("Experience not found.");

        _mapper.Map(dto, experience);

        await _jobSeekerRepository.UpdateExperienceAsync(experience);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task DeleteExperienceAsync(Guid experienceId)
    {
        var experience = await _jobSeekerRepository.GetExperienceAsync(experienceId);

        if (experience == null)
            throw new Exception("Experience not found.");

        await _jobSeekerRepository.DeleteExperienceAsync(experience);
        await _jobSeekerRepository.SaveChangesAsync();
    }

    public async Task<CvMetadataDto?> GetCvMetadataAsync(Guid userId)
    {
        var profile = await _jobSeekerRepository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var metadata = await _cvMetadataRepository.GetByProfileIdAsync(profile.Id);

        if (metadata == null)
            return null;

        return _mapper.Map<CvMetadataDto>(metadata);
    }
    public async Task UploadCvAsync(Guid userId, UploadCvDto dto)
    {
        var profile = await _jobSeekerRepository.GetProfileWithCvAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found.");

        var storedFileName = await _cvStorageService.UploadAsync(dto.File);

        if (profile.CvMetadata == null)
        {
            var metadata = new CvMetadata
            {
                Id = Guid.NewGuid(),
                JobSeekerProfileId = profile.Id,
                OriginalFileName = dto.File.FileName,
                StoredFileName = storedFileName,
                ContentType = dto.File.ContentType,
                FileSize = dto.File.Length,
                UploadedAt = DateTime.UtcNow
            };

            await _cvMetadataRepository.AddAsync(metadata);
        }
        else
        {
            await _cvStorageService.DeleteAsync(profile.CvMetadata.StoredFileName);

            profile.CvMetadata.OriginalFileName = dto.File.FileName;
            profile.CvMetadata.StoredFileName = storedFileName;
            profile.CvMetadata.ContentType = dto.File.ContentType;
            profile.CvMetadata.FileSize = dto.File.Length;
            profile.CvMetadata.UploadedAt = DateTime.UtcNow;

            await _cvMetadataRepository.UpdateAsync(profile.CvMetadata);
        }

        await _cvMetadataRepository.SaveChangesAsync();
    }

    public async Task<(FileStream Stream, string ContentType, string FileName)> DownloadCvAsync(Guid userId)
    {
        var profile = await _jobSeekerRepository.GetProfileWithCvAsync(userId);

        if (profile == null || profile.CvMetadata == null)
            throw new Exception("CV not found.");

        var stream = await _cvStorageService.DownloadAsync(profile.CvMetadata.StoredFileName);

        return (
            stream,
            profile.CvMetadata.ContentType,
            profile.CvMetadata.OriginalFileName
        );
    }
}