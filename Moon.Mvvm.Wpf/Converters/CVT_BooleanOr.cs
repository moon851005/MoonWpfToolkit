using System.Globalization;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    public class CVT_BooleanOr: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
                              object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (value is bool b && b)
                    return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
                                    object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
