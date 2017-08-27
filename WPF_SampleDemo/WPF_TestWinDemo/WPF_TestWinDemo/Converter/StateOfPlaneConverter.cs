using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_TestWinDemo.Converter
{
    public class StateOfPlaneConverter : IValueConverter
    {
        //双向绑定
        //源向目标的转化
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "OnAir":
                    return true;
                case "OnLand":
                    return false;
                case "Unknow":
                default:
                    return null;
            }
        }
        //目标向源的转化
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? s = (bool?)value;
            switch (s)
            {
                case true:
                    return "OnAir";
                case false:
                    return "OnLand";
                case null:
                default:
                    return "Unknow";
            }
        }
    }
}
