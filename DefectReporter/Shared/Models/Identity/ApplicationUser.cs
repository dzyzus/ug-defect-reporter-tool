<<<<<<< HEAD
﻿namespace DefectReporter.Shared.Models.Identity
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
        [InverseProperty("Owner")]
        public List<Defect> Defects { get; set; }

        [InverseProperty("Owner")]
        public List<Comment> Comments { get; set; }

        [InverseProperty("CurrentUser")]
        public List<Defect> CurrentUserDefects { get; set; }
=======
﻿using Microsoft.AspNetCore.Identity;

namespace DefectReporter.Shared.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
>>>>>>> 66555a5994784c2829e624147c64dc89ac1ae17d
    }
}