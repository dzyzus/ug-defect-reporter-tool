namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    #endregion

    /// <summary>
    /// The feature.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// The ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The release name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The features.
        /// </summary>
        public List<Feature>? Features { get; set; }

        /// <summary>
        /// The software builds.
        /// </summary>
        public List<SoftwareBuild>? SoftwareBuilds { get; set; }

        /// <summary>
        /// The defect.
        /// </summary>
        public List<Defect>? Defects { get; set; }
    }
}
