using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSizeScreen
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		double windowW,fontsize1,fontsize2;
		public MainWindow()
		{
			this.InitializeComponent();
			windowW=this.Width;
			fontsize1=this.textblock1.FontSize;
			fontsize2=this.ritchtextbox.FontSize;
			this.me.Play();
		}

		private void Window_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			double a=this.ActualWidth/windowW;
			this.textblock1.FontSize=fontsize1*a;
			this.ritchtextbox.FontSize=fontsize2*a;
		}

		private void b2_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.me.Pause();
		}

		private void b3_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.me.Play();
		}

		private void b4_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.me.Stop();
		}

		private void b1_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.me.Stop();
			this.me.Play();
		}
	}
}