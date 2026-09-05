using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Extensions;
using SmartRecruitmentMatchingPlatform.API.Mapping;
using SmartRecruitmentMatchingPlatform.API.Validators;
using SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Dependency Injection
builder.Services.AddProjectServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<UpdateJobSeekerProfileValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateNotificationDtoValidator>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();