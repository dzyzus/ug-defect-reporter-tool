namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        /// The title of defect.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The features.
        /// </summary>
        public List<Feature> Features { get; set; }
    }
}
