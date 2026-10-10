using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class CVT_InvertedBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                return !boolValue;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                return !boolValue; // 反轉布林值
            return false; // 預設回傳 false
        }
    }
}
