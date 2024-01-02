#region Usings

using DefectReporter.Shared.Enums;
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
        /// The comments.
        /// </summary>
        public List<Comment>? Comments { get; set; }

        /// <summary>
        /// The defect owner id.
        /// </summary>
        public string? OwnerId { get; set; }

        /// <summary>
        /// The defect owner name.
        /// </summary>
        public string? OwnerName { get; set; }

        /// <summary>
        /// The current user id.
        /// </summary>
        public string? CurrentUserId { get; set; }

        /// <summary>
        /// The current user name.
        /// </summary>
        public string? CurrentuserName { get; set; }

        /// <summary>
        /// The release.
        /// </summary>
        [ForeignKey("ReleaseId")]
        public Release? Release { get; set; }

        /// <summary>
        /// The release id.
        /// </summary>
        public int? ReleaseId { get; set; }

        /// <summary>
        /// The value which indicates regression
        /// </summary>
        public bool IsRegression { get; set; }

        /// <summary>
        /// The value which indicates defect is fixed.
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// The defect completed reason.
        /// </summary>
        public DefectCompletedReasonEnum? CompletedReason { get; set; }

        /// <summary>
        /// The fixed on version
        /// </summary>
        public string? FixedOnVersion { get; set; }

        /// <summary>
        /// The date time of created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The defect status.
        /// </summary>
        public DefectStatusEnum Status { get; set; }

        /// <summary>
        /// The component.
        /// </summary>
        public ComponentEnum Component { get; set; }

        /// <summary>
        /// The date time of end.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// The software build.
        /// </summary>
        [ForeignKey("SoftwareId")]
        public SoftwareBuild? SoftwareBuild { get; set; }

        /// <summary>
        /// The software id.
        /// </summary>
        public int? SoftwareId { get; set; }

        /// <summary>
        /// The list with emails of users involved.
        /// </summary>
        [NotMapped]
        public List<string> UsersInvolvedEmails { get; set; }
    }
}
