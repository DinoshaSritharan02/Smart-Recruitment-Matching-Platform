using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Extensions;
using SmartRecruitmentMatchingPlatform.API.Helpers;
using SmartRecruitmentMatchingPlatform.API.Mapping;
using SmartRecruitmentMatchingPlatform.API.Matching;
using SmartRecruitmentMatchingPlatform.API.Middleware;
using SmartRecruitmentMatchingPlatform.API.Repositories;
using SmartRecruitmentMatchingPlatform.API.Repositories.Implementations;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Services;
using SmartRecruitmentMatchingPlatform.API.Services.Implementations;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Validators;
using SmartRecruitmentMatchingPlatform.API.Validators.Auth;


var builder = WebApplication.CreateBuilder(args);

#region Database

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Controllers

builder.Services.AddControllers();

#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



#region Repository Registration

builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IMatchingRepository, MatchingRepository>();
builder.Services.AddScoped<IMatchingEngine, MatchingEngine>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IContactRequestRepository, ContactRequestRepository>();
builder.Services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICvMetadataRepository, CvMetadataRepository>();

#endregion

#region Service Registration

builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IMatchingService, MatchingService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IContactRequestService, ContactRequestService>();
builder.Services.AddScoped<IJobSeekerService, JobSeekerService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICvStorageService, CvStorageService>();

#endregion
builder.Services.AddScoped<JwtTokenGenerator>();

#region JWT Authentication

builder.Services.AddJwtAuthentication(builder.Configuration);

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion

#region FluentValidation

builder.Services.AddValidatorsFromAssemblyContaining<RegisterJobSeekerValidator>();

#endregion

#region Swagger

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {new OpenApiSecurityScheme
{
    Reference = new Microsoft.OpenApi.Models.OpenApiReference
    {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
    }
},
            Array.Empty<string>()
        }
    });
});

#endregion



var app = builder.Build();


#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("Angular");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion