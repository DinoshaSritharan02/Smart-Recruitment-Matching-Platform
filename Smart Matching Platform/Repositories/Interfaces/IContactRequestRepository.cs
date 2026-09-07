using SmartRecruitmentMatchingPlatform.API.Models.Entities;

namespace SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;

public interface IContactRequestRepository
{
    Task<ContactRequest?> GetByIdAsync(int id);

    Task<IEnumerable<ContactRequest>> GetForJobSeekerAsync(Guid jobSeekerProfileId);
    Task<bool> ExistsPendingRequestAsync(
    int employerId,
    Guid jobSeekerProfileId);

    Task AddAsync(ContactRequest request);

    Task UpdateAsync(ContactRequest request);

    Task SaveChangesAsync();
}