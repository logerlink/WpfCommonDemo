using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.Demo.ConverterHelper
{
    class StateConverter
    {
    }

    /// <summary> 
    /// state转文字  指定传进来的是int类型，回传回去的是string类型
    /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    public class StateToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(value?.ToString(),out int intValue);
            return intValue == 1?"完成":"取消";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> 
    /// state转 Brushes
    /// </summary>
    public class StateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int.TryParse(value?.ToString(), out int intValue);
            return intValue == 1 ? Brushes.Blue : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> 
    /// state转文字  指定传进来的是int类型，回传回去的是string类型
    /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    public class StateParamToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = parameter?.ToString() ?? "";
            int.TryParse(value?.ToString(), out int intValue);
            return intValue == 1 ? "完成"+ str : "取消";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    

    /// <summary>
    /// state count 为null "" 返回红色
    /// state == 0 返回红色
    /// state == 1 && count>=5 返回黄色
    /// state == 1 返回蓝色
    /// true 返回 Visible
    /// </summary>
    public class StateCountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values == null || values.Length < 2) return Brushes.Red;
                var state = values[0]?.ToString();
                var count = values[1]?.ToString();
                if(string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(count)) return Brushes.Red;
                int.TryParse(state,out int stateInt);
                int.TryParse(count, out int countInt);
                if(stateInt == 0) return Brushes.Red;
                else
                {
                    return countInt >= 5 ? Brushes.Yellow : Brushes.Blue;
                }
            }
            catch (Exception)
            {
                return Brushes.Red;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
