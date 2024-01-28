namespace DefectReporter.Server.Controllers
{
    #region Usings

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Shared.Models.Application;
    using DefectReporter.Shared.Services;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;
    using System.Text.RegularExpressions;

    #endregion

    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        /// <summary>
        /// The db context.
        /// </summary>
        private readonly DefectReporterContext _context;

        /// <summary>
        /// The email service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// The email controller.
        /// </summary>
        /// <param name="emailService">
        /// The email service.
        /// </param>
        /// <param name="context">
        /// The db context.
        /// </param>
        public EmailController(IEmailService emailService, DefectReporterContext context)
        {
            this._context = context;
            this.emailService = emailService;
        }

        /// <summary>
        /// The defect send emails notify.
        /// </summary>
        /// <param name="defect">
        /// The defect model.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpPost("defectSendEmails")]
        public async Task<IActionResult> DefectSendEmails([FromBody] Defect defect)
        {
            List<string> usersEmails = defect.UsersInvolvedEmails.Split(";").ToList();

            string[] text = defect.Description.Split('\n');

            StringBuilder parsedText = new StringBuilder();
            string currentIndentation = "";

            foreach (var line in text)
            {
                Match match = Regex.Match(line, @"^\d+(\.\d+)?");

                if (match.Success)
                {
                    parsedText.AppendLine($"{currentIndentation}{match.Value}.<br>");
                    currentIndentation = line.Substring(0, line.IndexOf(match.Value) + match.Length);
                    parsedText.AppendLine($"{currentIndentation}{line.Substring(match.Length).TrimStart()}");
                }
                else
                {
                    parsedText.AppendLine(line);
                }
            }

            string body = String.Empty;

            body += $"<b>Owner:</b> {defect.OwnerName}<br>";
            body += $"<b>Component:</b> {defect.Component}<br>";

            body += "<br>" + parsedText.ToString();

            try
            {
                foreach (var userEmail in usersEmails)
                {
                    if (defect.OwnerName.Contains(userEmail))
                    {
                        await emailService.SendEmailAsync(userEmail, $"[OWNER] [DEFECT CREATED] {defect.Title}", body);
                    }
                    else
                    {
                        await emailService.SendEmailAsync(userEmail, $"[DEFECT CREATED] {defect.Title}", body);
                    }
                }

                return Ok("Emails sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to send emails.");
            }
        }

        /// <summary>
        /// The defect update emails notify.
        /// </summary>
        /// <param name="defect">
        /// The defect model.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpPost("updateSendEmails")]
        public async Task<IActionResult> UpdateSendEmails([FromBody] Defect defect)
        {
            List<string> usersEmails = defect.UsersInvolvedEmails.Split(";").ToList();

            string body = $"Defect was updated. Please review changes.";

            try
            {
                foreach (var userEmail in usersEmails)
                {
                    if (defect.OwnerName.Contains(userEmail))
                    {
                        await emailService.SendEmailAsync(userEmail, $"[OWNER] [DEFECT UPDATED] - {defect.Title}", body);
                    }
                    else
                    {
                        await emailService.SendEmailAsync(userEmail, $"[DEFECT UPDATED] - {defect.Title}", body);

                    }
                }

                return Ok("Emails sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to send emails.");
            }
        }

        /// <summary>
        /// The comment send emails notify.
        /// </summary>
        /// <param name="comment">
        /// The comment.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        [HttpPost("commentSendEmails")]
        public async Task<IActionResult> CommentSendEmails([FromBody] Comment comment)
        {
            Defect defect = this._context.Defects.Where(defect => defect.Id == comment.DefectId).FirstOrDefault();

            string title = $"[DEFECT NOTIFY] {defect.Title}";
            string body = $"<b>{comment.FullName}</b> addded new comment below this defect.<br><b>Content:</b>{comment.Content}";

            List<string> usersEmails = defect.UsersInvolvedEmails.Split(";").ToList();

            try
            {
                foreach (var userEmail in usersEmails)
                {
                    await emailService.SendEmailAsync(userEmail, title, body);
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
