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
using System.Collections.ObjectModel;

namespace GoSun.WPFTest
{
    /// <summary>
    /// ListBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxDemo : Window
    {
        public ListBoxDemo()
        {
            InitializeComponent();
            IniData();
            BindingData();
        }

        private ObservableCollection<Student> stuList = new ObservableCollection<Student>();

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
        }

        private void BindingData()
        {
            this.listBoxStudents.ItemsSource = stuList;

            //Binding binding = new Binding("SelectedItem.Id") { Source = this.listBoxStudents };
            //this.textBoxId.SetBinding(TextBox.TextProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //stuList.RemoveAt(stuList.Count - 1);
            stuList[0].Id += 1;
        }

    }
}
