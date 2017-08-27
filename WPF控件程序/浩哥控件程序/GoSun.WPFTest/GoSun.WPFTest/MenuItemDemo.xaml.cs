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
    /// MenuItemDemo.xaml 的交互逻辑
    /// </summary>
    public partial class MenuItemDemo : Window
    {
        public MenuItemDemo()
        {
            InitializeComponent();
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("右键菜单");
        }
    }
}
