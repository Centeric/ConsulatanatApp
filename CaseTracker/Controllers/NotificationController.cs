using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.DataLogics.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ApplicationDbContext _context;
        public NotificationController(INotificationService notificationService, ApplicationDbContext context)
        {
            _context = context;
            _notificationService = notificationService;
        }

        [HttpGet("GetNotitifications")]
        public async Task<IActionResult> GetAllNotifications()
        {
            try
            {
                var notifications = await _context.Notifications
                    .Select(n => new NotificationResponse
                    {
                        NotificationId = n.NotificationId,
                        Title = n.Title,
                        Body = n.Body,
                        NotificationDate = n.NotificationDate.ToString("dd-MM-yyyy"),
                        IsSeen = n.IsSeen
                    })
                    .ToListAsync();
                return Ok(new { Message = "Notifications Loaded Successfully",  notifications });
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("mark-as-seen/{id}")]
        public async Task<IActionResult> MarkAsSeen(int NotificationId)
        {
            var notification = await _context.Notifications.FindAsync(NotificationId);
            if (notification == null) return NotFound("Error");

            notification.IsSeen = true;
            await _context.SaveChangesAsync();
            return Ok("Saved Successfully");
        }
    }
}
