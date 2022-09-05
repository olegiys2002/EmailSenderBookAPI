using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public NotificationController()
        {

        }
        [HttpGet]
        
        public IActionResult GetNotifications()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateNotification()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification()
        {
            return Ok();
        }
        

    }
}
