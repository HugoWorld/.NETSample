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
using System.ComponentModel;  //INotifyPropertyChanged接口

namespace Sample.Demo
{
    /// <summary>
    /// BindingDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BindingDemo : Window
    {
        Person p;
        public BindingDemo()
        {
            InitializeComponent();
            //两种方法建立绑定
            p = new Person();
            if (!String.IsNullOrEmpty( tb_Age.Text))
            { 
                p.Age = Convert.ToInt32(tb_Age.Text); 
            }

            Binding bd = new Binding();
            bd.Source = p;
            bd.Path = new PropertyPath("Age");
            BindingOperations.SetBinding(this.tb_Age, TextBox.TextProperty, bd);
            this.tb_slider.SetBinding(Slider.ValueProperty,new Binding("Value"){Source=slider1=new Slider(){Value= Convert.ToInt32(tb_slider.Text)}});           //this.tb_Name.SetBinding(TextBox.TextProperty, new Binding("Age")
            //{
            //    Source = p = new Person(this.tb_Name.Text, int.Parse(this.tb_Age.Text), this.tb_Hobby.Text) 
            //                           { Age = Convert.ToInt32(tb_Age.Text) },
            //      Mode = BindingMode.OneWayToSource
            //});
        }

        private void bt_Input_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text != null && tb_Age.Text != null && this.tb_Hobby.Text != null)
            {
                p = new Person(this.tb_Name.Text, int.Parse(this.tb_Age.Text), this.tb_Hobby.Text);
            }
            else
            {
                MessageBox.Show("请填写相关信息！");
            }
        }
    }
    //一般的实现方式
    public class Person:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private int age;
        private string name = "";
        private string hobby = "";
        public Person()
        {
            age = 0;
            name = "";
            hobby = "";
        }
        public Person(string name_str,int ages,string hobby_str)
        {
            age = ages;
            name = name_str;
            hobby = hobby_str;
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                if (this.PropertyChanged != null)
                {   // 通知Binding是“Age”这个属性的值改变了    
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));            
                }
            }
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Hobby
        {
            get 
            {
                return this.hobby;
            }
            set
            {
                hobby=value;
                if(this.PropertyChanged!=null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Hobby")); 
                }
            }
        }
    }



}
