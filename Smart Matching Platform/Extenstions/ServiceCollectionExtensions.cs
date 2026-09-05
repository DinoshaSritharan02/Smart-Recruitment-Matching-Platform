
using SmartRecruitmentMatchingPlatform.API.Helpers;
using SmartRecruitmentMatchingPlatform.API.Repositories;
using SmartRecruitmentMatchingPlatform.API.Services;

namespace SmartRecruitmentMatchingPlatform.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
        services.AddScoped<ICvMetadataRepository, CvMetadataRepository>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJobSeekerService, JobSeekerService>();

        services.AddScoped<ICvStorageService, CvStorageService>();
        services.AddScoped<JwtTokenGenerator>();

        return services;
    }
}