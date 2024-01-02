using DefectReporter.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DefectReporter.Server.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("sendEmails")]
        public async Task<IActionResult> SendEmails([FromBody] List<string> userEmails)
        {
            try
            {
                foreach (var userEmail in userEmails)
                {
                    await emailService.SendEmailAsync(userEmail, "New Defect Notification", "There is a new defect in the system. Please review.");
                }

                return Ok("Emails sent successfully.");
            }
            catch (Exception ex)
            {
                // Logowanie błędu lub inna obsługa błędów
                return BadRequest("Failed to send emails.");
            }
        }
    }
}
