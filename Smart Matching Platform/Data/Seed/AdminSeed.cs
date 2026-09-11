using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Helpers;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmartRecruitmentMatchingPlatform.API.Data.Seed;

public static class AdminSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                FirstName = "System",
                LastName = "Administrator",
                Email = "admin@smart.com",
                PasswordHash = PasswordHashHelper.HashPassword("Admin@123"),
                Role = UserRole.Administrator,
                IsActive = true,
                CreatedAt = new DateTime(2026, 9, 11)
            });
    }
}