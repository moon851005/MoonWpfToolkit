using System.Globalization;
using System.Windows.Data;

namespace Moon.Mvvm.Wpf.Converters
{
    /// <summary>
    /// 通用相等性比較轉換器
    /// 支援 int 和 string 類型的比較
    /// </summary>
    public class CVT_Compare : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 如果沒有提供參數,返回 false
            if (parameter == null)
                return false;

            // 處理 int 類型比較
            if (value is int intValue)
            {
                // 嘗試將 parameter 轉換為 int
                if (parameter is int intParam)
                {
                    return intValue == intParam;
                }
                else if (parameter is string strParam && int.TryParse(strParam, out int parsedParam))
                {
                    return intValue == parsedParam;
                }
                return false;
            }

            // 處理 string 類型比較
            if (value is string strValue)
            {
                string paramStr = parameter.ToString();
                return string.Equals(strValue, paramStr, StringComparison.Ordinal);
            }

            // 處理 Enum 類型比較
            if (value is Enum enumValue)
            {
                // parameter 也是 Enum 類型，直接比較
                if (parameter is Enum enumParam)
                {
                    return enumValue.Equals(enumParam);
                }
                // parameter 是 int，與 Enum 的底層值比較
                else if (parameter is int intParam)
                {
                    return System.Convert.ToInt32(enumValue) == intParam;
                }
                // parameter 是 string，嘗試解析為 Enum 名稱或底層值
                else if (parameter is string strParam)
                {
                    // 移除可能的類型前綴（例如 "PermissionMode.Guest" -> "Guest"）
                    string enumName = strParam;
                    int lastDotIndex = strParam.LastIndexOf('.');
                    if (lastDotIndex >= 0 && lastDotIndex < strParam.Length - 1)
                    {
                        enumName = strParam[(lastDotIndex + 1)..];
                    }

                    // 嘗試按名稱比較
                    if (Enum.TryParse(enumValue.GetType(), enumName, true, out object parsedEnum))
                    {
                        return enumValue.Equals(parsedEnum);
                    }
                    // 嘗試按底層 int 值比較
                    else if (int.TryParse(enumName, out int parsedInt))
                    {
                        return System.Convert.ToInt32(enumValue) == parsedInt;
                    }
                }
                return false;
            }

            // 其他類型使用 Equals 比較
            return value?.Equals(parameter) ?? false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("CVT_Compare does not support ConvertBack");
        }
    }
}
