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
    /// ListViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewDemo : Window
    {
        public ListViewDemo()
        {
            InitializeComponent();
            IniData();
        }
        private List<Student> stuList = new List<Student>();

        private void IniData()
        {
            Student stu = new Student() { Id = 1, Name = "Tim", Age = 10 };
            stuList.Add(stu);
            stu = new Student() { Id = 2, Name = "Tom", Age = 11 };
            stuList.Add(stu);
            stu = new Student() { Id = 3, Name = "Kyle", Age = 12 };
            stuList.Add(stu);
            stu = new Student() { Id = 4, Name = "Tony", Age = 13 };
            stuList.Add(stu);
            stu = new Student() { Id = 5, Name = "Vina", Age = 14 };
            stuList.Add(stu);

            this.ListViewStudent.ItemsSource = stuList;
        }
    }
}
