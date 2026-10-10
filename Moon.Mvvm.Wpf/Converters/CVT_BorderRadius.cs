using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    public class CVT_BorderRadius : IValueConverter
    {
        // value: CornerRadius, parameter: 乘數 (1, 2, 4個數字)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not CornerRadius original)
                return new CornerRadius(0);

            if (parameter is string paramStr)
            {
                var parts = paramStr.Split([' ', ',', ';'], StringSplitOptions.RemoveEmptyEntries);
                double[] factors = [1, 1, 1, 1];
                if (parts.Length == 1 && double.TryParse(parts[0], out double f1))
                {
                    factors = [f1, f1, f1, f1];
                }
                else if (parts.Length == 2 && double.TryParse(parts[0], out double f2a) && double.TryParse(parts[1], out double f2b))
                {
                    // top/bottom, left/right
                    factors = [f2a, f2b, f2a, f2b];
                }
                else if (parts.Length == 4 &&
                    double.TryParse(parts[0], out double f4a) &&
                    double.TryParse(parts[1], out double f4b) &&
                    double.TryParse(parts[2], out double f4c) &&
                    double.TryParse(parts[3], out double f4d))
                {
                    // top-left, top-right, bottom-right, bottom-left
                    factors = [f4a, f4b, f4c, f4d];
                }
                // else: fallback to all 1
                return new CornerRadius(
                    original.TopLeft * factors[0],
                    original.TopRight * factors[1],
                    original.BottomRight * factors[2],
                    original.BottomLeft * factors[3]
                );
            }
            // fallback: 1
            return original;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
