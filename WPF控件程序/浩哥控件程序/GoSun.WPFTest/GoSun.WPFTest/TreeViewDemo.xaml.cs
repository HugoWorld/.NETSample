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
using GoSun.WPFTest.Model;

namespace GoSun.WPFTest
{
    /// <summary>
    /// TreeViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewDemo : Window
    {
        public TreeViewDemo()
        {
            InitializeComponent();
            InitData();
        }

        List<Node> nodes = new List<Node>();
        private void InitData()
        {
            Node node = new Node() { ID = 1, Name = "中国",Type = 1 };
            nodes.Add(node);
            node = new Node() { ID = 2, Name = "广东省",ParentID = 1,Type = 2 };
            nodes.Add(node);
            node = new Node() { ID = 3, Name = "广州市", ParentID = 2, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID = 4, Name = "深圳市", ParentID = 2, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID = 5, Name = "揭阳市", ParentID = 2, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID = 6, Name = "湖南省", ParentID = 1, Type = 2 };
            nodes.Add(node);
            node = new Node() { ID = 7, Name = "长沙市", ParentID = 6, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID = 8, Name = "普宁市", ParentID = 5, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID =9, Name = "洪阳镇", ParentID = 8, Type = 3 };
            nodes.Add(node);
            node = new Node() { ID = 10, Name = "大圆", ParentID = 9, Type = 3 };
            nodes.Add(node);
             // 绑定树
            List<Node> outputList = Bind(nodes);
            //(TreeView.SelectedItem as Node).ID
            this.TreeView.ItemsSource = outputList;
            //TreeViewItem item = new TreeViewItem();
            //item.Header = "";

        }

          /// <summary>
        /// 绑定树
        /// </summary>
        List<Node> Bind(List<Node> nodes)
        {
            List<Node> outputList = new List<Node>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ParentID == -1)
                {
                    outputList.Add(nodes[i]);
                }
                else
                {
                    FindDownward(nodes, nodes[i].ParentID).Nodes.Add(nodes[i]);
                }
            }
            return outputList;
        }
        /// <summary>
        /// 递归向下查找
        /// </summary>
        Node FindDownward(List<Node> nodes, int id)
        {
            if (nodes == null) return null;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ID == id)
                {
                    return nodes[i];
                }
                Node node = FindDownward(nodes[i].Nodes, id);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Node node = (Node)TreeView.SelectedItem;
            if(node.Type == 3)
            MessageBox.Show(node.Name);
        }

    }
}
