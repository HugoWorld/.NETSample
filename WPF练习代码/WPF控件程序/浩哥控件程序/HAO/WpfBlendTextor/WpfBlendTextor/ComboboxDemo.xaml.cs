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

namespace WpfBlendTextor
{
    /// <summary>
    /// ComboboxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ComboboxDemo : Window
    {
        public ComboboxDemo()
        {
            InitializeComponent();
            initData();
        }
        private List<string> nameList;

        private void initData()
        {
            nameList = new List<string>() { "天河区", "越秀区", "黄埔区", "番禺区", "增城区", "从化区", "海珠区", "花都区", "白云区", "南沙区" };
            this.NameList.ItemsSource = nameList;
        }
    }
}
