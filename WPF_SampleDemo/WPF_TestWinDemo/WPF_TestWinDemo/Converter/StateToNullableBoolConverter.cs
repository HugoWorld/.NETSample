using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_TestWinDemo.Converter
{
    public class StateToNullableBoolConverter : IValueConverter
    {
        public object Convert(object value, Type outputType, object parameter, CultureInfo culture)
        {
            State e = (State)value;
            switch (e)
            {
                case State.Avaliable:
                    return true;
                case State.Locked:
                    return false;
                case State.Unknown:
                default:
                    return null;
            }

        }
        public object ConvertBack(object value, Type outputType, object parameter, CultureInfo culture)
        {
            bool? nb = (bool?)value;
            switch (nb)
            {
                case true:
                    return State.Avaliable;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;
            }
        }
    }

}
