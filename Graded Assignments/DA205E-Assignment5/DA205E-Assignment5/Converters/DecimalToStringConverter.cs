// Sixten Peterson (AQ9300) 2026-05-18
using System.Globalization;
using System.Windows.Data;

namespace DA205E_Assignment5.Converters
{
    /// <summary>
    /// Converter class used for converting between decimal and string.
    /// </summary>
    ///
    public class DecimalToStringConverter : IValueConverter
    {

        /// <summary>
        /// Converts a decimal to a string.
        /// </summary>
        /// <param name="value">The value to convert form decimal to string</param>
        /// <param name="targetType">optional (not used)</param>
        /// <param name="parameter">optional (not used)</param>
        /// <param name="culture">optional (not used)</param>
        /// <returns>The decimal as a string if a decimal was provided, empty string if not.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue.ToString(culture);
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts string back to decimal (if possible)
        /// </summary>
        /// <param name="value">The string to convert back to decimal</param>
        /// <param name="targetType">optional (not used)</param>
        /// <param name="parameter">optional (not used)</param>
        /// <param name="culture">optional (not used)</param>
        /// <returns>The string as a decimal if the conversion was succesful, 0 as a decimal if unsuccessful.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (decimal.TryParse(value as string, NumberStyles.Any, culture, out decimal decimalValue))
            {
                return decimalValue;
            }

            return 0m;
        }
    }
}
