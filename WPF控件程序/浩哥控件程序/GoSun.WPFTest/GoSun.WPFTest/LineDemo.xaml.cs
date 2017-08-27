using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoSun.WPFTest
{
    /// <summary>
    /// LineDemo.xaml 的交互逻辑
    /// </summary>
    public partial class LineDemo : Window
    {
        public LineDemo()
        {
            InitializeComponent();
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = 1;
            myLine.X2 = 50;
            myLine.Y1 = 1;
            myLine.Y2 = 50;
            grid.Children.Add(myLine);
            Line myLine1 = new Line();
            myLine1.Stroke = System.Windows.Media.Brushes.Blue;
            myLine1.X1 = 50;
            myLine1.X2 = 100;
            myLine1.Y1 = 50;
            myLine1.Y2 = 100;
            grid.Children.Add(myLine1);
        }
    }
}
