using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories;

public class JobSeekerRepository : IJobSeekerRepository
{
    private readonly ApplicationDbContext _context;

    public JobSeekerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<JobSeekerProfile?> GetByUserIdAsync(Guid userId)
    {
        return await _context.JobSeekerProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<JobSeekerProfile?> GetProfileWithDetailsAsync(Guid userId)
    {
        return await _context.JobSeekerProfiles
            .Include(x => x.User)
			.Include(x => x.JobSeekerSkills)
	             .ThenInclude(x => x.Skill)
			.Include(x => x.Educations)
            .Include(x => x.Experiences)
            .Include(x => x.CvMetadata)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
    public async Task AddProfileAsync(JobSeekerProfile profile)
    {
        await _context.JobSeekerProfiles.AddAsync(profile);
    }

    public async Task CreateProfileAsync(JobSeekerProfile profile)
    {
        await _context.JobSeekerProfiles.AddAsync(profile);
    }

    public Task UpdateProfileAsync(JobSeekerProfile profile)
    {
        _context.JobSeekerProfiles.Update(profile);
        return Task.CompletedTask;
    }

    public async Task AddSkillAsync(JobSeekerSkill skill)
    {
        await _context.JobSeekerSkills.AddAsync(skill);
    }

    public Task RemoveSkillAsync(JobSeekerSkill skill)
    {
        _context.JobSeekerSkills.Remove(skill);
        return Task.CompletedTask;
    }

	public async Task<JobSeekerSkill?> GetSkillAsync(Guid profileId, int skillId)
	{
		return await _context.JobSeekerSkills
			.FirstOrDefaultAsync(x =>
				x.JobSeekerProfileId == profileId &&
				x.SkillId == skillId);
	}

	public async Task AddEducationAsync(Education education)
    {
        await _context.Educations.AddAsync(education);
    }

    public Task UpdateEducationAsync(Education education)
    {
        _context.Educations.Update(education);
        return Task.CompletedTask;
    }

    public Task DeleteEducationAsync(Education education)
    {
        _context.Educations.Remove(education);
        return Task.CompletedTask;
    }

    public async Task<Education?> GetEducationAsync(Guid educationId)
    {
        return await _context.Educations.FindAsync(educationId);
    }

    public async Task AddExperienceAsync(Experience experience)
    {
        await _context.Experiences.AddAsync(experience);
    }

    public Task UpdateExperienceAsync(Experience experience)
    {
        _context.Experiences.Update(experience);
        return Task.CompletedTask;
    }

    public Task DeleteExperienceAsync(Experience experience)
    {
        _context.Experiences.Remove(experience);
        return Task.CompletedTask;
    }

    public async Task<Experience?> GetExperienceAsync(Guid experienceId)
    {
        return await _context.Experiences.FindAsync(experienceId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<JobSeekerProfile?> GetProfileWithCvAsync(Guid userId)
    {
        return await _context.JobSeekerProfiles
            .Include(x => x.CvMetadata)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}