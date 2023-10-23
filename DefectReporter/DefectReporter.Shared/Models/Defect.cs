#region Usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace DefectReporter.Shared.Models
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
        public List<Comment> Comments { get; set; }
    }
}
