using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace Smart_Matching_Platform.Data.Seed
{
    public static class SkillSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "ASP.NET Core" },
                new Skill { Id = 3, Name = "Java" },
                new Skill { Id = 4, Name = "Python" },
                new Skill { Id = 5, Name = "JavaScript" },
                new Skill { Id = 6, Name = "TypeScript" },
                new Skill { Id = 7, Name = "Angular" },
                new Skill { Id = 8, Name = "React" },
                new Skill { Id = 9, Name = "SQL" },
                new Skill { Id = 10, Name = "Entity Framework Core" }
            );
        }
    }
}