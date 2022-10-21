using Core.IServices;
using EmailSender.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
           var notifications = await _notificationService.GetAllNotifications();
           return notifications == null ? NotFound() : Ok(notifications);
        }

        [HttpGet("{id}")]       
        public async Task<IActionResult> GetNotification(string id)
        {
            await _notificationService.GetNotification(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(string id)
        {
            await _notificationService.DeleteNotification(id);
            return Ok(id);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNotification(NotificationDTO notificationDTO)
        {
            await _notificationService.CreateNotification(notificationDTO);
            return Ok(notificationDTO);
        }
        

    }
}
