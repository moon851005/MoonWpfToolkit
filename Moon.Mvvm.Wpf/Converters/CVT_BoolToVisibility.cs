using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    public class CVT_BoolToVisibility : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPriority = false;
            bool isInvert = false;
            bool isHidden = false;

            //參數解析
            if (parameter is string paramStr)
            {
                var parts = paramStr.Split([',', ';', ' '], StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim().ToLower());
                foreach (var part in parts)
                {
                    switch (part.Trim().ToLower())
                    {
                        case "priority":
                            isPriority = true;
                            break;
                        case "invert":
                            isInvert = true;
                            break;
                        case "hidden":
                            isHidden = true;
                            break;
                    }
                }
            }

            bool b = false;
            if(value is bool bb)
            {
                b = bb;
            }

            if (isInvert)
            {
                b = !b;
            }

            if (b)
            {
                return Visibility.Visible;
            }
            else
            {
                if (isPriority)
                {
                    return DependencyProperty.UnsetValue;
                }
                else
                {
                    return isHidden ? Visibility.Hidden : Visibility.Collapsed;
                }
            }

        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //參數解析
            if (parameter is string paramStr)
            {
                bool isOR = false;
                bool isAND = false;
                bool isXOR = false;
                bool isNOT = false;
                bool isHidden = false;

                var parts = paramStr.Split([',', ';', ' '], StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim());
                foreach (var part in parts)
                {
                    switch (part.Trim())
                    {
                        case "AND":
                        {
                            isAND = true;
                            break;
                        }
                        case "OR":
                        {
                            isOR = true;
                            break;
                        }
                        case "XOR":
                        {
                            isXOR = true;
                            break;
                        }
                        case "NOT":
                        {
                            isNOT = true;
                            break;
                        }
                        case "Hidden":
                        {
                            isHidden = true;
                            break;
                        }
                    }
                }

                if (isNOT)
                {
                    bool andResult = true;
                    foreach (var value in values)
                    {
                        if (value is bool b && !b)
                        {
                            andResult = false;
                            break;
                        }
                    }
                    return andResult ? (isHidden ? Visibility.Hidden : Visibility.Collapsed) : Visibility.Visible;
                }

                if (isAND)
                {
                    bool andResult = true;
                    foreach (var value in values)
                    {
                        if (value is bool b && !b)
                        {
                            andResult = false;
                            break;
                        }
                    }
                    return andResult ? Visibility.Visible : isHidden ? Visibility.Hidden : Visibility.Collapsed;
                }

                if (isOR)
                {
                    bool orResult = false;
                    foreach (var value in values)
                    {
                        if (value is bool b && b)
                        {
                            orResult = true;
                            break;
                        }
                    }
                    return orResult ? Visibility.Visible : isHidden ? Visibility.Hidden : Visibility.Collapsed;
                }

                if (isXOR)
                {
                    bool xorResult = false;
                    int trueCount = 0;
                    foreach (var value in values)
                    {
                        if (value is bool b && b)
                        {
                            trueCount++;
                        }
                    }
                    xorResult = (trueCount == 1);
                    return xorResult ? Visibility.Visible : isHidden ? Visibility.Hidden : Visibility.Collapsed;
                }
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => Binding.DoNothing;
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => null;
    }
}
