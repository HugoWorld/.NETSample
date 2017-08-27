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

namespace WpfBlendTextor
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
            initData();
			// 在此点下面插入创建对象所需的代码。
		}
        private List<string> nameList;
        private void initData()
        {
            nameList = new List<string>() { "高仙底盘", "ROCKET", "Tank_11414" };
            this.NameList.ItemsSource = nameList;
        }
	}
}