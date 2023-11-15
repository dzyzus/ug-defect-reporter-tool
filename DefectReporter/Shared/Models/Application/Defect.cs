#region Usings

using DefectReporter.Shared.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace DefectReporter.Shared.Models.Application
{
    /// <summary>
    /// The defect - article model.
    /// </summary>
    public class Defect
    {
        /// <summary>
        /// The ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title of defect.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The description of defect.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The software build.
        /// </summary>
        [Required]
        public string SoftwareBuild { get; set; }

        /// <summary>
        /// The comments.
        /// </summary>
        public List<Comment>? Comments { get; set; }

        /// <summary>
        /// The defect owner.
        /// </summary>
        [ForeignKey("OwnerId")]
        public ApplicationUser? Owner { get; set; }

        /// <summary>
        /// The defect owner id.
        /// </summary>
        public string? OwnerId { get; set; }

        /// <summary>
        /// The current user.
        /// </summary>
        [ForeignKey("CurrentUserId")]
        public ApplicationUser? CurrentUser { get; set; }

        /// <summary>
        /// The current user id.
        /// </summary>
        public string? CurrentUserId { get; set; }

        /// <summary>
        /// The release.
        /// </summary>
        [ForeignKey("ReleaseId")]
        public Release? Release { get; set; }

        /// <summary>
        /// The release id.
        /// </summary>
        public int? ReleaseId { get; set; }
    }
}
