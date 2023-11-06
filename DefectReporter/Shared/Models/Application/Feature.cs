namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The feature.
    /// </summary>
    public class Feature
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
        /// The release.
        /// </summary>
        [ForeignKey("ReleaseId")]
        public Release Release { get; set; }

        /// <summary>
        /// The release id.
        /// </summary>
        public int ReleaseId { get; set; }
    }
}
