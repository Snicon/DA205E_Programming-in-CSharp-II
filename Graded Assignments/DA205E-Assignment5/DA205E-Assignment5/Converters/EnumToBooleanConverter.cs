// Sixten Peterson (AQ9300) 2026-05-18
using System.Globalization;
using System.Windows.Data;

namespace DA205E_Assignment5.Converters
{
    /// <summary>
    /// In short this class is used to convert between an enum value and a bool. Its used in the main window to determine if a RadioButton is checked.
    /// For more context see the expense, revenue and all radio button options uinder the search and filter section.
    /// </summary>
    class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(parameter) ?? parameter == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
