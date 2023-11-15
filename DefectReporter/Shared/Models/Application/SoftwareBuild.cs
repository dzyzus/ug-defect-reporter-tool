using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectReporter.Shared.Models.Application
{
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
        public string Version { get; set; }

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
