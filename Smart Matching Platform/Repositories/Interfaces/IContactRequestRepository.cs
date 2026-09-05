using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

public interface IContactRequestRepository
{
    Task<ContactRequest?> GetByIdAsync(int id);

    Task<IEnumerable<ContactRequest>> GetForJobSeekerAsync(int jobSeekerProfileId);

    Task AddAsync(ContactRequest request);

    Task UpdateAsync(ContactRequest request);

    Task SaveChangesAsync();
}