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
using System.Windows.Shapes;

namespace WPF_TestWinDemo
{
    /// <summary>
    /// Command_Win.xaml 的交互逻辑
    /// </summary>
    public partial class Command_Win : Window
    {
        public Command_Win()
        {
            InitializeComponent();

            //声明命令并使用命令源和目标与之关联
            ClearCommand clearcmd = new ClearCommand();
            this.ctrlClear.Command = clearcmd;
            this.ctrlClear.CommandTarget = this.miniView;
        }

        /************************************使用命令*****************************/
        //需求：定义一个命令，使用Button发送这个命令。
        //      当命令送达TextBox时，TextBox会被清空（若TextBox没有文字则命令不可清空

        //第1步：声明并定义命令
        private RoutedCommand ClearCmd = new RoutedCommand("Clear", typeof(Command_Win));
        public void InitializeCommand()
        {
            //第2步：把命令赋值给命令源（发送者）并指定快捷键
            button1.Command = ClearCmd;
            this.ClearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //第3步：指定命令目标
            this.button1.CommandTarget = this.tb1;

            //第4步：创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this.ClearCmd;

            //只关注与ClearCmd相关的事件
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Excuted);

            //第5步：把命令关联安置在View层的外围控件StackPanel上
            this.sp1.CommandBindings.Add(cb);
        }
        //当探测命令是否可以执行时，此方法被调用
        private void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb1.Text))
            {
                e.CanExecute = false;
            }
            else
            { e.CanExecute = true; }

            //避免继续向上传而降低程序性能
            e.Handled = true;

        }

        //当命令送达目标后，此方法被调用
        private void cb_Excuted(object sender,ExecutedRoutedEventArgs e)
        {
            this.tb1.Clear();
            //避免继续向上传，降低程序性能
            e.Handled = true;
        }


        /************************************ 命令源
         情    景： 当一个按键用来新建 Teacher 的档案，另一个按键用来新建 Student档案时，程序应该如何区别新建的是什么档案。
         解决方案： 使用CommandParameter，命令源需实现 ICommandSource 接口
        *****************************/
        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tb1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void New_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            string name = this.tb1.Text;
            if(e.Parameter.ToString()=="Teacher")
            {
                this.lb_Newinfo.Items.Add(string.Format("NewTeacher:{0}，学而不厌，诲人不倦",name));
            }
            else if(e.Parameter.ToString()=="Student")
            {
                this.lb_Newinfo.Items.Add((String.Format("New Student{0},好好学习，天天向上", name)));
            }
        }
    }


    /************************************ 自定义命令源 和 自定义命令
    打造纯手工的自定义命令。不使用外围控件实现CommandBinding接收路由事件，再执行命令。
    更改后的业务逻辑： 命令源发送命令到命令目标，由命令目标自己判断是否可以执行命令。
    *****************************/
    /// <summary>
    /// 使用IView接口约束接受该命令的命令目标所需包含的属性及方法
    /// </summary>
    public interface IView
    {
        bool IsChanged { get; set; }
        void SetBinding();
        void Refresh();
        void Clear();
        void Save();
    }
    /// <summary>
    /// 自定义命令
    /// </summary>
    public class ClearCommand:ICommand
    {
        //当命令可执行状态发生改变时，应当被激发
        public event EventHandler CanExecuteChanged;

        //用于判断命令是否可以执行
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 命令执行，带有与业务相关的Clear逻辑
        /// 传入的对象如果是IView类，而且非空，则执行其清除方法
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if(view!=null)
            {
                view.Clear();
            }
        }
 
    }
    /// <summary>
    /// 自定义命令源
    /// 以往是使用控件的RaiseEvent方法把命令（炮弹）发送出去
    /// 现在，则需要自定义该控件的触发方式，从而发送命令
    /// </summary>
    public class MyCommandSource : UserControl, ICommandSource
    {
        //继承自ICommandSource的三个属性
        public ICommand Command{ get;set;}
        public object CommandParameter{ get; set; }
        public IInputElement CommandTarget { get; set; }

        //在组件被单击时连带执行命令
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if(this.CommandTarget!=null)
            {
                this.Command.Execute(this.CommandTarget);
            }
        }
    }
}
