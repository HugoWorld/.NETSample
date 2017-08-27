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
using System.Runtime.InteropServices;
using GoSun.WPFTest.Common;

namespace GoSun.WPFTest
{
    /// <summary>
    /// WindowDemo.xaml 的交互逻辑
    /// </summary>
    public partial class WindowDemo : Window
    {
        public WindowDemo()
        {
            InitializeComponent();
            


        }

        Window subWin;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.MoveWindowTest(this, 0, 0, 400, 400);
            WindowHelper.MoveWindowTest(subWin, 100, 100, 400, 400);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            subWin = new Window();
            //subWin.WindowState = System.Windows.WindowState.Maximized;
            subWin.WindowStyle = WindowStyle.None;
            subWin.ShowInTaskbar = false;
            subWin.Width = 400;
            subWin.Height = 500;
            subWin.Owner = this;
            this.PreviewKeyDown += Window_PreviewKeyDown;
            subWin.PreviewKeyDown += Window_PreviewKeyDown;
            subWin.Show();
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString().ToUpper();
            if (key == "A")
            {
                //subWin.Width = 1920;
                //subWin.Height = 1080;
                WindowHelper.MoveWindowTest(this, 0, 0, 400, 400);
                WindowHelper.MoveWindowTest(subWin, 100, 100, 400, 400);
            }
            e.Handled = true;
        }



    }
}
