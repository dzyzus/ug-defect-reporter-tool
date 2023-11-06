using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefectReporter.Shared.Models.Application
{
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
    }
}
