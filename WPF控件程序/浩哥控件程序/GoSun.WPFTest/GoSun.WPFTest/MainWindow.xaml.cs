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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoSun.WPFTest.Common;
using System.Timers;

namespace GoSun.WPFTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (timer.Enabled == false)
            {
                timer.Start();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (timer.Enabled == true)
            {
                timer.Stop();
            }
        }

        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += time_elapse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_elapse(object sender, ElapsedEventArgs e)
        {
            BeepUp.Beep(4000,400);
        }


    }
}
