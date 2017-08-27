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

    delegate void ReportTimeRouteEventHandler(object sender, ReportTimeEventArgs e);
    delegate void ThresholdCounterEventHandler<ThresholdCounterEventArgs>(object sender, ThresholdCounterEventArgs e);
    delegate void NameChangedEventHandler(object sender, RoutedEventArgs e);

    /// <summary>
    /// EventWin.xaml 的交互逻辑
    /// </summary>
    public partial class EventWin : Window
    {
        public EventWin()
        {
            InitializeComponent();
            //附加事件
            this.gridMain.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
            this.gridMain.AddHandler(Student1.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));
            // Student1.AddNameChangedEventHandler(this.Background, new RoutedEventHandler(this.StudentNameChangedHandler));
        }
        /// <summary>
        /// 事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
           
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToString("yyyyMMddHHmmss");
            string content = string.Format("{0}到达{1}", timeStr, element.Name);
        }


        private void StudentNameChangedHandler(object sender,RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student1).Name.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student1 stu = new Student1
            {
                ID = 101,
                Name = "Tim"
            };
            stu.Name = "Tom";
            RoutedEventArgs args = new RoutedEventArgs(Student1.NameChangedEvent, stu);
            bt_ChangedName.RaiseEvent(args);
        }

        private void bt_OriginWPFEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bubble is here!");
            e.Handled = true;
        }


    }
    /*********************************传统路由事件*****************************************/
    /// <summary>
    /// 创建路由事件携带的消息类型,在此可以附加自己想要的信息
    /// </summary>
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
        public DateTime ClickTime { get; set; }
    }

    /// <summary>
    /// 创建路由事件拥有者
    /// </summary>
    public class TimeButton : Button
    {
        //1、为元素声明并注册事件
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble,
                                                             typeof(ReportTimeRouteEventHandler), typeof(TimeButton));
        //2、使用CLR属性包装事件
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }
        //3、触发事件
        protected override void OnClick()
        {
            base.OnClick();
            //创建路由事件携带消息实例，与事件关联
            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            //使用RaiseEvent方法激活路由事件
            this.RaiseEvent(args);
        }

       
    }


    /*********************************传统附加事件*****************************************/
    /// <summary>
    /// 先定义一个包含附加事件的类
    /// 附加事件的声明和路由事件完全一样，和路由事件不同的是它并非派生自UIElement
    /// 因此没有AddHandler和RemoveHandler两个方法，且没有RaiseEvent这个方法可以激发事件
    /// 只能附加到UIElment对象上面进行激发。
    /// </summary>
    public class Student1
    {
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble,
                                                                                             typeof(RoutedEvent), typeof(Student));
        public int ID{get;set;}
        public string Name { get; set; }
        public static void AddNameChangedEventHandler(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if(e!=null)
            {
                //只能附加到UIElment对象上面进行激发 NameChangedEvent 事件
                e.AddHandler(Student1.NameChangedEvent, h);
            }
        }
        public static void RemoveNameChangedEventHandler(DependencyObject d, RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e != null)
            {
                e.RemoveHandler(Student1.NameChangedEvent, h);
            }
        }
    }

    /*********************************路由事件的EventHandler<ThresholdCounterEventArgs>表达*****************************************/
    public class ThresholdCounterEventArgs : RoutedEventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
    class Counter:Button
    {
        public static readonly RoutedEvent ThresholdCounterEvent = EventManager.RegisterRoutedEvent("ThresholdReached",
            RoutingStrategy.Bubble, typeof(ThresholdCounterEventHandler<ThresholdCounterEventArgs>), typeof(Counter));
        private int threshold;
        private int total;

        public event ThresholdCounterEventHandler<ThresholdCounterEventArgs> ThresholdCounter
        {
            add { this.AddHandler(ThresholdCounterEvent, value); }
            remove { this.RemoveHandler(ThresholdCounterEvent, value); }
        }
        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }
        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdCounterEventArgs args = new ThresholdCounterEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdCounterEventArgs e)
        {           
            ThresholdCounterEventArgs TCE_Args = new ThresholdCounterEventArgs();
            TCE_Args.Threshold = 10;
            TCE_Args.TimeReached =DateTime.Now;
            this.RaiseEvent(TCE_Args);
          
        }

      
    }

    /*********************************传统CLR事件的EventHandler<ThresholdCounterEventArgs>表达*****************************************/
    /// <summary>
    /// 快递邮件消息
    /// </summary>
    public class SendMessageEventArgs : EventArgs
    {
        private int ID = 0;
        private string ReceivedMessage_Name = "";
        private string From = "";
        private string To = "";
        private string SendMessage_Name = "";
        private DateTime date;
        public int MessageID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Received_Name
        {
            get { return ReceivedMessage_Name; }
            set { ReceivedMessage_Name = value; }
        }
        public string Sender_Name
        {
            get { return SendMessage_Name; }
            set { SendMessage_Name = value; }
        }
        public string TaretAddress
        {
            get { return To; }
            set { To = value; }
        }
        public string SenderAddress
        {
            get { return From; }
            set { From = value; }
        }
    }
    class PostOffice
    {
        public delegate void SendMessageEventHandler<SendMessageEventArgs>(object sender, SendMessageEventArgs e);
        public event SendMessageEventHandler<SendMessageEventArgs> SendMessageEvent;
        private int mail_ID;
        private int total;
        public PostOffice(SendMessageEventArgs e)
        {
           if(e!=null)
            {
                GetMail(e);
            }
        }
        public void GetMail( SendMessageEventArgs e)
        {
            SendMessageEventHandler<SendMessageEventArgs> SendMailHandler = SendMessageEvent;
            if(SendMailHandler != null)
            {
                SendMailHandler(this,e);//发起事件
            }
        }
    }

    class Officer
    {
        int w_ID = 0;
        public Officer(int work_ID)
        {
            w_ID = work_ID;
        }
        public void Go(object sender, SendMessageEventArgs sm)
        {
            Console.WriteLine("ID为：", w_ID, "的快递员准备出发！！");
        }
    
        
    }


    /*********************************传统CLR事件*****************************************/

    //所有订阅者【Subscriber】感兴趣的对象，也就是e,都要继承微软的EventArgs
    //本例中订阅者【也称观察者】MrMing，MrZhang他们感兴趣的e对象，就是杂志【magazine】
    public class PubEventArgs : EventArgs
    {
        public readonly string magazineName;
        public PubEventArgs()
        {

        }
        public PubEventArgs(string magazineName)
        {
            this.magazineName = magazineName;
        }
    }

    //发布者（Publiser)
    public class Publisher
    {
        //声明一个出版的委托
        //这里多了一个参数sender,它所代表的就是Subject，也就是监视对象，本例中就是Publisher
        public delegate void PublishEventHandler(object sender, PubEventArgs e);

        //在委托的机制下我们建立以个出版事件
        public event PublishEventHandler Publish;

        //声明一个可重写的OnPublish的保护函数
        protected virtual void OnPublish(PubEventArgs e)
        {
            if (Publish != null)
            {
                //Sender = this，也就是Publisher
                this.Publish(this, e);
            }
        }

        //事件必须要在方法里去触发
        public void issue(string magazineName)
        {
            OnPublish(new PubEventArgs(magazineName));
        }
    }

    //Subscriber 订阅者
    public class MrMing
    {
        //对事件感兴趣的事情
        public static void Receive(object sender, PubEventArgs e)
        {
            Console.WriteLine("嘎嘎，我已经收到最新一期的《" + e.magazineName + "》啦！！");
        }
    }

    public class MrZhang
    {
        //对事件感兴趣的事情
        public static void Receive(object sender, PubEventArgs e)
        {
            Console.WriteLine("幼稚，这么大了，还看《火影忍者》，SB小明！");
            Console.WriteLine("这个我定的《" + e.magazineName + "》，哇哈哈！");
        }
    }
}
