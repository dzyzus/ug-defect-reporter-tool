namespace DefectReporter.Shared.Models.Identity
{
    #region Usings

    using DefectReporter.Shared.Models.Application;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
    }
}