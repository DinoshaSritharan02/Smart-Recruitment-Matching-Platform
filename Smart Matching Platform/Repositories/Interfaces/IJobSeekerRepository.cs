using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories;

public interface IJobSeekerRepository
{
    Task<JobSeekerProfile?> GetByUserIdAsync(Guid userId);

    Task<JobSeekerProfile?> GetProfileWithDetailsAsync(Guid userId);
    Task AddProfileAsync(JobSeekerProfile profile);

    Task CreateProfileAsync(JobSeekerProfile profile);

    Task UpdateProfileAsync(JobSeekerProfile profile);

    Task AddSkillAsync(JobSeekerSkill skill);

    Task RemoveSkillAsync(JobSeekerSkill skill);

    Task<JobSeekerSkill?> GetSkillAsync(Guid profileId, int skillId);

    Task AddEducationAsync(Education education);

    Task UpdateEducationAsync(Education education);

    Task DeleteEducationAsync(Education education);

    Task<Education?> GetEducationAsync(Guid educationId);

    Task AddExperienceAsync(Experience experience);

    Task UpdateExperienceAsync(Experience experience);

    Task DeleteExperienceAsync(Experience experience);

    Task<Experience?> GetExperienceAsync(Guid experienceId);

    Task SaveChangesAsync();
    Task<JobSeekerProfile?> GetProfileWithCvAsync(Guid userId);
}