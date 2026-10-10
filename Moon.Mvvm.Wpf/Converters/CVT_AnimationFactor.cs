using System;
using System.Globalization;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    // 複製自 PresentationFramework.Fluent 的 AnimationFactorToValueConverter
    // 用於 Expander 滑入/滑出動畫：result = size * factor（negative 時取負）
    public class CVT_AnimationFactor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double size && values[1] is double factor)
                return parameter?.ToString() == "negative" ? -size * factor : size * factor;
            return 0.0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
