using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirebaseMessagingBackendService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromBody] MessageRequest request)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = request.Title,
                    Body = request.Body,
                },
                Data = new Dictionary<string, string>()
                {
                    ["CustomData"] = "Hello, how are you doing?"
                },
                Token = request.DeviceToken
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);

            if (!string.IsNullOrEmpty(result))
            {
                // Message was sent successfully
                return Ok("Message sent successfully!");
            }
            else
            {
                // There was an error sending the message
                throw new Exception("Error sending the message.");
            }
        }
    }
}
