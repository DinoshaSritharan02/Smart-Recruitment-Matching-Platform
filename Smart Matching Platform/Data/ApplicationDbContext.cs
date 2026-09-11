using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data.Configurations;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Data.Seed;


namespace SmartRecruitmentMatchingPlatform.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<JobSeekerProfile> JobSeekerProfiles => Set<JobSeekerProfile>();

    public DbSet<JobSeekerSkill> JobSeekerSkills => Set<JobSeekerSkill>();

    public DbSet<Education> Educations => Set<Education>();

    public DbSet<Experience> Experiences => Set<Experience>();

    public DbSet<CvMetadata> CvMetadatas => Set<CvMetadata>();

    public DbSet<Notification> Notifications => Set<Notification>();

    public DbSet<ContactRequest> ContactRequests => Set<ContactRequest>();
    public DbSet<Employer> Employers => Set<Employer>();

    public DbSet<Vacancy> Vacancies => Set<Vacancy>();

    public DbSet<Skill> Skills => Set<Skill>();

    public DbSet<VacancySkill> VacancySkills => Set<VacancySkill>();

    public DbSet<Application> Applications => Set<Application>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        SkillSeed.Seed(modelBuilder);
        AdminSeed.Seed(modelBuilder);
    }
}