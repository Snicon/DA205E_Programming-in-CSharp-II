// Sixten Peterson (AQ9300) 2026-06-04
using DA205E_Assignment6.Models;
using System.Globalization;
using System.Windows.Data;

namespace DA205E_Assignment6.UI.Converters
{
    public class LiteratureCollectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var literatureCollection = value as List<Literature>;

            if (literatureCollection == null || literatureCollection.Count == 0)
                return "No literature added yet...";

            return string.Join(", ", literatureCollection.Select(l => l.Title));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
