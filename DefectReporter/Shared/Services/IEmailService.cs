namespace DefectReporter.Shared.Services
{
    /// <summary>
    /// The email service.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// The send email.
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
        Task SendEmailAsync(string to, string subject, string body);
    }

}
