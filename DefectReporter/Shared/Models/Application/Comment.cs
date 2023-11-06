﻿using DefectReporter.Shared.Models.Identity;
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

        /// <summary>
        /// The application user.
        /// </summary>
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// The user is - foreign key.
        /// </summary>
        public string UserId { get; set; }
    }
}