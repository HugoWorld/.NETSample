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

namespace GosunRobotClientControlStyle
{
    /// <summary>
    /// Animation.xaml 的交互逻辑
    /// </summary>
    public partial class Animation : Window
    {
        public Animation()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pp = Mouse.GetPosition(this);
            if (pp.X >= 10 && pp.X <= 446 && pp.Y >= 190 && pp.Y <= 350)
            {
            }
            else
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
        }
    }
}
