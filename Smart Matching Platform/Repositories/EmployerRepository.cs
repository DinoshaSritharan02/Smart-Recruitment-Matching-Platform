using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employer?> GetByIdAsync(int id)
        {
            return await _context.Set<Employer>()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employer?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Set<Employer>()
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task AddAsync(Employer employer)
        {
            await _context.Set<Employer>().AddAsync(employer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employer employer)
        {
            _context.Set<Employer>().Update(employer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await _context.Set<Employer>()
                .AnyAsync(e => e.UserId == userId);
        }
    }
}