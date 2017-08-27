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
    /// ComboBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ComboBoxDemo : Window
    {
        public ComboBoxDemo()
        {
            InitializeComponent();
            initData();
            initData2();
        }
        private List<string> nameList;
        private void initData()
        {
            nameList = new List<string>() { "高仙底盘", "ROCKET", "Tank_11414" };
            this.NameList.ItemsSource = nameList;
        }

        private List<string> nameList2;

        private void initData2()
        {
            nameList2 = new List<string>() { "天河区", "越秀区", "黄埔区", "番禺区", "增城区", "从化区", "海珠区", "花都区", "白云区", "南沙区" };
            this.NameList2.ItemsSource = nameList2;
        }
    }
}
