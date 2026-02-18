// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Utils
{
    /// <summary>
    /// Utility for reading numeric input from text fields or other controls. The logic is mostly based on the help Faird has provided in the LMS but written on my own.
    /// </summary>
    public static class NumericUtility
    {
        #region Constants to avoid magic numbers
        private const double DefaultNumberInCaseOfInvalidInputDouble = 0.0;
        #endregion

        /// <summary>
        /// Takes any string and tries to convert it into a double.
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A tuple consisting of the converted number as a double along with a bool (true) if conversion was successful. 0.0 and false if unsuccessful.</returns>
        public static (double, bool) GetDouble(string value)
        {
            if (double.TryParse(value, out double number)) // Trying to parse
            {
                return (number, true); // Parsed successfully and therefore returning the data
            }

            return (DefaultNumberInCaseOfInvalidInputDouble, false); // Parsing/conversion failed
        }
    }
}
