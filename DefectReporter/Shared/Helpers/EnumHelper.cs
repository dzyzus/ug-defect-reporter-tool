namespace DefectReporter.Shared.Helpers
{
    #region Usings

    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    /// The enum helper.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Get display name.
        /// </summary>
        /// <param name="value">
        /// The enum value.
        /// </param>
        /// <returns>
        /// Returns the display attribute of enum.
        /// </returns>
        public static string GetDisplayName(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayAttribute));

                if (displayAttribute != null)
                {
                    return displayAttribute.GetName();
                }
            }

            return value.ToString();
        }
    }
}
