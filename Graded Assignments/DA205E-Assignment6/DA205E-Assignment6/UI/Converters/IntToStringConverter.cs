// Sixten Peterson (AQ9300) 2026-06-04
using System.Globalization;
using System.Windows.Data;

namespace DA205E_Assignment6.UI.Converters
{
    /// <summary>
    /// A converter used to convert ints to string (and back). Used in the WPF GUI for some
    /// properties that are of the int data type.
    /// </summary>
    public class IntToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts int to a string.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The int as a string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
                return intValue.ToString(culture);

            return string.Empty;
        }

        /// <summary>
        /// Converts a string back to int.
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The string as an int</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value as string, NumberStyles.Any, culture, out int intValue))
                return intValue;

            return 0;
        }
    }
}
