using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;
using SmartRecruitmentMatchingPlatform.API.Repositories.Interfaces;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Services.Implementations;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly IMapper _mapper;

    public AdminService(
        IAdminRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserSummaryDto>> GetAllUsersAsync()
    {
        var users = await _repository.GetAllUsersAsync();

        return _mapper.Map<IEnumerable<UserSummaryDto>>(users);
    }

    public async Task<UserSummaryDto?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);

        return user == null ? null : _mapper.Map<UserSummaryDto>(user);
    }

    public async Task UpdateUserStatusAsync(int id, UpdateUserStatusDto dto)
    {
        var user = await _repository.GetUserByIdAsync(id);

        if (user == null)
            throw new Exception("User not found.");

        user.IsActive = dto.IsActive;

        await _repository.SaveChangesAsync();
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        return new DashboardDto
        {
            TotalUsers = await _repository.GetTotalUsersAsync(),
            TotalJobSeekers = await _repository.GetTotalJobSeekersAsync(),
            TotalEmployers = await _repository.GetTotalEmployersAsync(),
            TotalVacancies = await _repository.GetTotalVacanciesAsync(),
            TotalApplications = await _repository.GetTotalApplicationsAsync()
        };
    }
}