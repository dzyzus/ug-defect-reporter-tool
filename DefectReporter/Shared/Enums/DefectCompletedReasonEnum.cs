using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DefectReporter.Shared.Enums
{
    public enum DefectCompletedReasonEnum
    {
        /// <summary>
        /// In progress
        /// </summary>
        [Display(Name = "In progress")]
        InProgress = 0,

        /// <summary>
        /// Not a defect.
        /// </summary>
        [Display(Name = "Not a defect")]
        NotADefect,

        /// <summary>
        /// Fixed.
        /// </summary>
        [Display(Name = "Fixed")]
        Fixed,

        /// <summary>
        /// Will not be fixed.
        /// </summary>
        [Display(Name = "Will be not fixed")]
        WillBeNotFixed
    }
}
