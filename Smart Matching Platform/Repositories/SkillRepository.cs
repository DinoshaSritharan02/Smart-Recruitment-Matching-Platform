using Microsoft.EntityFrameworkCore;
using SmartRecruitmentMatchingPlatform.API.Data;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Set<Skill>()
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Set<Skill>()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Skill?> GetByNameAsync(string name)
        {
            return await _context.Set<Skill>()
                .FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}