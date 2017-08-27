using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace WPF_TestWinDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 实现的是txt2 依赖于 Student对象 依赖于 txt1
        /// </summary>
        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();

            // stu.SetValue(Student.NameProperty,binding);
            //BindingOperations操作绑定的静态类
            //下面区分两个SetBinding方法，返回值都为BindingExpressionBase类型，
            //一个是FrameworkElement的方法,stu.SetBinding(Student.NameProperty, binding);

            Binding binding = new Binding("Text") { Source = txt1 };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            RangeValidationRule rvr = new RangeValidationRule();
            rvr.ValidatesOnTargetUpdated = true;
            binding.ValidationRules.Add(rvr);

            //设置验证错误提示，可看作报警器
            //它会沿着目标，传到安装处理报警的地方
            binding.ValidatesOnNotifyDataErrors = true;
            binding.NotifyOnTargetUpdated = true;

            //添加对源和目标的更新的监视，设置ToolTip为空
            this.TargetUpdated += new EventHandler<DataTransferEventArgs>(MainWindow_TargetUpdated);
            this.SourceUpdated += new EventHandler<DataTransferEventArgs>(MainWindow_SourceUpdated);
            
            //添加侦听事件接口
            this.txt2.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidError));

            //一个是BindingOperations的方法,BindingOperations.SetBinding(stu,Student.NameProperty,binding);
            stu.SetBinding(Student.NameProperty, binding);
            this.txt2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //有了Name这个CLR属性，下面的两局的效果是一样的
            MessageBox.Show(stu.Name.ToString());
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Student stud = new Student();
            stud.SetValue(Student.NameProperty, "KaKit");
        
        }
        /// <summary>
        /// 数据源更新函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            (sender as MainWindow).txt2.ToolTip = "";
        }
        /// <summary>
        /// 目标对象数据更新函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            (sender as MainWindow).txt2.ToolTip = "";
        }
        /// <summary>
        /// 数据校验失败函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValidError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.txt2).Count > 0)
            {
                this.txt2.ToolTip = Validation.GetErrors(this.txt2)[0].ErrorContent.ToString();
                e.Handled = true;
            }
        }

        private void ConvertButton_Click_1(object sender, RoutedEventArgs e)
        {
            List<Plane> planeList = new List<Plane>()
            {
                new Plane() {Category=Category.Plane,Name="B-1",State=State.Unknown },
                new Plane() {Category=Category.Paperplane,Name="B-2",State=State.Avaliable },
                new Plane() {Category=Category.Plane,Name="B-3",State=State.Avaliable },
                new Plane() {Category=Category.Plane,Name="B-4",State=State.Locked},
                new Plane() {Category=Category.Paperplane,Name="B-5",State=State.Avaliable },
                new Plane() {Category=Category.Paperplane,Name="B-6",State=State.Locked },
                new Plane() {Category=Category.Plane,Name="B-7",State=State.Unknown },
            };
            this.LB.ItemsSource = planeList;

        }
    }
    /// <summary>
    /// 依赖属性
    /// </summary>
    public class Student : DependencyObject //声明一个对象，并继承DependencyObject类
        {
            //该项为依赖属性NameProperty的声明
            //NameProperty为命名规范
            //第一个参数（我们以前用的CLR属性）一致,然后加上Property。
            //第二个参数是“字段”的类型;
            //第三个为依赖属性的宿主（目标Target）的类型
            //第四个参数,在此不作说明，具体用到再去研究
            public static readonly DependencyProperty NameProperty =DependencyProperty.Register("Name", typeof(string), typeof(Student));

            //定义一个CLR属性来读写的依赖属性读写的值
            //作用：以“实例属性”的形式向外界暴露依赖属性
            public string Name
            {
                get { return (string)GetValue(NameProperty); }
                set { SetValue(NameProperty, value); }
            }

            /// <summary>
            /// SetBinding方法是FrameworkElement里面的方法，在依赖属性里这样做，是为了让目标对象能想UI控件一样绑定在依赖对象上
            /// 该方法是为了将依赖属性绑定到依赖对象（UI控件的依赖属性上）
            /// 或者说以第三人称的视角，将数据源于目标对象关联起来
            /// </summary>
            /// <param name="dp"></param>
            /// <param name="binding"></param>
            /// <returns></returns>
            public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
            {
                return BindingOperations.SetBinding(this, dp, binding);
            }

        }
    /// <summary>
    /// 附加属性
    /// </summary>
    public class School : DependencyObject
    {
        public static int GetGrade(DependencyObject obj)
        {
            return (int)obj.GetValue(GradeProperty);
        }

        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new UIPropertyMetadata(0));
    }

    /// <summary>
    /// 校验规则
    /// </summary>
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(), out d))
            {
                if (d >= 0 && d <= 80)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "输入数字不合理！！");
        }
    }

    public class Plane
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }
    public enum State
    {
        Avaliable,
        Locked,
        Unknown
    }
    public enum Category
    {
        Paperplane,
        Plane
    }
    /// <summary>
    /// 数据转换器
    /// </summary>
  
 
 
}
