using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _adminService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPatch("users/{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(
            int id,
            UpdateUserStatusDto dto)
        {
            await _adminService.UpdateUserStatusAsync(id, dto);

            return NoContent();
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var dashboard = await _adminService.GetDashboardAsync();

            return Ok(dashboard);
        }
    }
}