using System.ComponentModel;

namespace DefectReporter.Shared.Enums
{
    public enum DefectCompletedReasonEnum
    {
        /// <summary>
        /// Not a defect.
        /// </summary>
        [Description("Not a defect")]
        NotADefect = 0,

        /// <summary>
        /// Fixed.
        /// </summary>
        [Description("Fixed")]
        Fixed,

        /// <summary>
        /// Will not be fixed.
        /// </summary>
        [Description("Will be not fixed")]
        WillBeNotFixed
    }
}
