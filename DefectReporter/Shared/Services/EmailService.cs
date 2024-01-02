namespace DefectReporter.Shared.Services
{
    #region Usings

    using System.Net;
    using System.Net.Mail;

    #endregion

    /// <summary>
    /// The email service.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// The smtp server.
        /// </summary>
        private readonly string smtpServer = "smtp.gmail.com";

        /// <summary>
        /// The smtp port.
        /// </summary>
        private readonly int smtpPort = 587;

        /// <summary>
        /// The smtp username.
        /// </summary>
        private readonly string smtpUsername = "defectreporterapp@gmail.com";

        /// <summary>
        /// the smtp password.
        /// </summary>
        private readonly string smtpPassword = "coea ruru hefg nuqb";

        /// <summary>
        /// The send email async implementation.
        /// </summary>
        /// <param name="to">
        /// The receiver.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        ///  The body of msg.
        /// </param>
        /// <returns>
        /// Returns action status.
        /// </returns>
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
