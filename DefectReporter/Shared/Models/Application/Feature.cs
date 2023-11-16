namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using DefectReporter.Shared.Enums;
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
        /// The description of feature.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The component.
        /// </summary>
        [Required]
        public ComponentEnum Component { get; set; }

        /// <summary>
        /// The release.
        /// </summary>
        [ForeignKey("ReleaseId")]
        public Release? Release { get; set; }

        /// <summary>
        /// The release id.
        /// </summary>
        public int ReleaseId { get; set; }

        /// <summary>
        /// The tests assigned to feature.
        /// </summary>
        public List<Test>? Tests { get; set; }
    }
}
