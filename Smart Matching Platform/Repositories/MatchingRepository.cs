//using Microsoft.EntityFrameworkCore;
//using SmartRecruitmentMatchingPlatform.API.Data;
//using SmartRecruitmentMatchingPlatform.API.Models.Entities;

//namespace SmartRecruitmentMatchingPlatform.API.Repositories;

//public class MatchingRepository : IMatchingRepository
//{
//    private readonly ApplicationDbContext _context;

//    public MatchingRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<JobSeekerProfile?> GetJobSeekerAsync(Guid userId)
//    {
//        return await _context.JobSeekerProfiles
//            .Include(x => x.Skills)
//            .FirstOrDefaultAsync(x => x.UserId == userId);
//    }

//    public async Task<List<Vacancy>> GetAllVacanciesAsync()
//    {
//        return await _context.Vacancies
//            .Include(x => x.RequiredSkills)
//            .Include(x => x.Employer)
//            .ToListAsync();
//    }
//}