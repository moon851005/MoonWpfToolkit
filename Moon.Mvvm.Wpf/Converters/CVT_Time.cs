using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    public class CVT_Time : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int milliseconds)
            {
                var totalSeconds = milliseconds / 1000;
                var minutes = totalSeconds / 60;
                var seconds = totalSeconds % 60;

                return $"{minutes:D2}:{seconds:D2}";
            }

            return "00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
