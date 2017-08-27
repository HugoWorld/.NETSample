using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace GoSun.WPFTest.Common
{
    public class CityImgConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = System.Windows.Forms.Application.StartupPath;
            int type = (int)value;
            if (type == 1)
            {
                return new BitmapImage(new Uri(path + "\\Images\\球机.png"));
            }
            else
                if (type == 2)
                {
                    return new BitmapImage(new Uri(path + "\\Images\\球机_离线.png"));
                }
                else
                {
                    return new BitmapImage(new Uri(path + "\\Images\\球机.png"));
                }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
