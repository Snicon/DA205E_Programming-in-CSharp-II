// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.Model.Category;
using System.Globalization;
using System.Windows.Data;

namespace DA205E_Assignment5.Converters
{
    /// <summary>
    /// Converter class used to reutrn a nicley formatted category string, in effor to make the UI/UX a tad bit better.
    /// </summary>
    public class CategoryFormatConverter : IValueConverter
    {
        /// <summary>
        /// Converts a Category record into a formatted string that is ultimately displayed in the GUI.
        /// The result follows the following format: "Category name (Category type)"
        /// </summary>
        /// <param name="value">The category object that will be formatted.</param>
        /// <param name="targetType">Optional parameter of the binding target property (not used)</param>
        /// <param name="parameter">Optional parameter used in the converter logic (not used)</param>
        /// <param name="culture">The culture to use in the converter (not used)</param>
        /// <returns>A formatted string representing the category by displaying its name and type or an empty string if value is null or not a category object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var category = value as Category;
            return category != null ? $"{category.Name} ({category.Type})" : string.Empty; // Returning it nicley formatted if value is not null, if value is null just return empty string.
        }

        /// <summary>
        /// Not implemented, do not use.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
