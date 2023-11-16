namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using DefectReporter.Shared.Models.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The comment ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The content.
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// The defect.
        /// </summary>
        [ForeignKey("DefectId")]
        public Defect Defect { get; set; }

        /// <summary>
        /// The defect id.
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// The comment owner.
        /// </summary>
        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// The comment owner id - foreign key.
        /// </summary>
        public string? OwnerId { get; set; }
    }
}
