using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Implementations;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    public AdminRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<int> GetTotalUsersAsync()
    {
        return await _context.Users.CountAsync();
    }

    public async Task<int> GetTotalJobSeekersAsync()
    {
        return await _context.JobSeekerProfiles.CountAsync();
    }

    public async Task<int> GetTotalEmployersAsync()
    {
        return await _context.Employers.CountAsync();
    }

    public async Task<int> GetTotalVacanciesAsync()
    {
        return await _context.Vacancies.CountAsync();
    }

    public async Task<int> GetTotalApplicationsAsync()
    {
        return await _context.Applications.CountAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}