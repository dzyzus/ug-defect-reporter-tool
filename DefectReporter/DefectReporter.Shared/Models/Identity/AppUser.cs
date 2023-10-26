#region Usings

using Microsoft.AspNetCore.Identity;

#endregion

namespace DefectReporter.Shared.Models.Identity;

/// <summary>
/// The defect reporter user model.
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// The name.
    /// </summary>
    [PersonalData]
    public string Name { get; set; }

    /// <summary>
    /// The surname.
    /// </summary>
    [PersonalData]
    public string Surname { get; set; }
}

