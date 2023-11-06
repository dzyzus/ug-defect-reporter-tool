namespace DefectReporter.Shared.Models.Identity
{
    #region Usings

    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Identity;

    #endregion

    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The comment.
        /// </summary>
        public Comment? Comment { get; set; }
    }
}