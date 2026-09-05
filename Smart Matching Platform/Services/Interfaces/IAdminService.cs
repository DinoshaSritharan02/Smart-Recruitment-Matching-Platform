using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;

namespace SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

public interface IAdminService
{
    Task<IEnumerable<UserSummaryDto>> GetAllUsersAsync();

    Task<UserSummaryDto?> GetUserByIdAsync(int id);

    Task UpdateUserStatusAsync(int id, UpdateUserStatusDto dto);

    Task<DashboardDto> GetDashboardAsync();
}