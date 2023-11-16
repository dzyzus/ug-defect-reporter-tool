namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The software build.
    /// </summary>
    public class SoftwareBuild
    {
        /// <summary>
        /// The ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The version.
        /// </summary>
        [Required]
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// The release.
        /// </summary>
        [ForeignKey("ReleaseId")]
        public Release Release { get; set; }

        /// <summary>
        /// The release id.
        /// </summary>
        public int ReleaseId { get; set; }

        /// <summary>
        /// The defect.
        /// </summary>
        public Defect? Defect { get; set; }
    }
}
