using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;
using SmartRecruitmentMatchingPlatform.API.Services.Interfaces;
using System.Security.Claims;

namespace SmartRecruitmentMatchingPlatform.API.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var notifications = await _notificationService.GetNotificationsAsync(userId);

            return Ok(notifications);
        }

        [HttpPut("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationService.MarkAsReadAsync(id);

            return NoContent();
        }

        [HttpGet("unread")]
        [Authorize]
        public async Task<IActionResult> GetUnread()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            var notifications = await _notificationService.GetUnreadAsync(userId);

            return Ok(notifications);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);

            return NoContent();
        }
    }
}