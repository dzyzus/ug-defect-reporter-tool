namespace DefectReporter.Shared.Models.Application
{
    #region Usings

    using DefectReporter.Shared.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The test.
    /// </summary>
    public class Test
    {
        /// <summary>
        /// The test id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The test name.
        /// </summary>
        [Required]
        public string TestName { get; set; }

        /// <summary>
        /// The test case.
        /// </summary>
        [Required]
        public string TestCase { get; set; }

        /// <summary>
        /// The value which indicates test is automated.
        /// </summary>
        [Required]
        public bool IsAutomated { get; set; }

        /// <summary>
        /// The type of test.
        /// </summary>
        [Required]
        public TypeOfTest TypeOfTest { get; set; }

        /// <summary>
        /// The component.
        /// </summary>
        [Required]
        public ComponentEnum Component { get; set; }

        /// <summary>
        /// The feature.
        /// </summary>
        [ForeignKey("FeatureId")]
        public Feature? Feature { get; set; }

        /// <summary>
        /// The feature id.
        /// </summary>
        [Required]
        public int FeatureId { get; set; }
    }
}
