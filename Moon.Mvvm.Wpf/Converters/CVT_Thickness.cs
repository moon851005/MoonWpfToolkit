using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    public class CVT_Thickness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Thickness original || parameter is not string flagString)
                return new Thickness(0);

            var flags = flagString.Split(' ');
            if (flags.Length != 4)
                return original;

            double left = flags[0] == "1" ? original.Left : 0;
            double top = flags[1] == "1" ? original.Top : 0;
            double right = flags[2] == "1" ? original.Right : 0;
            double bottom = flags[3] == "1" ? original.Bottom : 0;

            return new Thickness(left, top, right, bottom);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
