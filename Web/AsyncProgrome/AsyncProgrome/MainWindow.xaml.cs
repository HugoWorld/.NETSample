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
using System.Threading;
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Threading;

namespace AsyncProgrome
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private BackgroundWorker m_BackgroundWorker;// 申明后台对象
        
        private void InitBackgroundWorker()
        {
            m_BackgroundWorker = new BackgroundWorker(); // 实例化后台对象

            m_BackgroundWorker.WorkerReportsProgress = true; // 设置可以通告进度
            m_BackgroundWorker.WorkerSupportsCancellation = true; // 设置可以取消

            m_BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            MainWindow win = e.Argument as MainWindow;

            int i = 0;
            while (i <= 100)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                bw.ReportProgress(i++);

                Thread.Sleep(1000);

            }
        }

        void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;

            label1.Content = string.Format("{0}", progress);
        }


        void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                MessageBox.Show("Completed");
            }
        }

        private void ThrowException(string _threadName,int i)
        {
            Exception ex = new Exception("这是" + _threadName + "的第" + i + "个异常。" + "\n");
            Dispatcher.BeginInvoke(new Action(() => {
                tb1.AppendText(ex.Message);
            }));
            throw ex;
        }

        private void SetMultiTask ()
        {
            Stopwatch _watch = new Stopwatch();
            _watch.Start();
            try
            {
                int rr = Task<int>.Factory.StartNew(() =>
                {
                    Dispatcher.BeginInvoke(new Action(() => {
                        tb1.AppendText("这是任务一！" + "\n");
                    }));
                    for (int i = 0; i < 10; i++)
                    {
                        ThrowException("任务一", i);
                    }
                    return 0;
                }).GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {
                
                Dispatcher.BeginInvoke(new Action(() => {
                    _watch.Stop();
                    tb1.AppendText("任务一中的所有异常已被处理！" + "\n");
                    tb1.AppendText("这是任务一，使用GetAwaiter().GetResult()的方法捕捉线程：" + _watch.Elapsed.ToString() + "毫秒！\n");
                    _watch.Reset();
                }));
            }

            Stopwatch _watch1 = new Stopwatch();
            _watch1.Start();
            var tt = Task<int>.Factory.StartNew(() =>
            {

                //Console.WriteLine("这是任务一！");
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    tb1.AppendText("这是任务一（1）！" + "\n");
                }));
                for (int i = 0; i < 10; i++)
                {
                    ThrowException("任务一（1）", i);
                }
                return 0;
            });

            tt.ContinueWith(t =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    tb1.AppendText("任务一(1)中的所有异常已被处理！" + "\n");
                    _watch1.Stop();
                    tb1.AppendText("这是任务一，使用ContinueWith()的方法捕捉线程：" + _watch1.Elapsed.ToString() + "毫秒！\n");
                    _watch1.Reset();
                }));
                //Console.WriteLine("所有异常已被处理！");
            }, TaskContinuationOptions.OnlyOnFaulted);



            Stopwatch _watch11 = new Stopwatch();
            _watch11.Start();
            var tt11 = Task<int>.Factory.StartNew(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    tb1.AppendText("这是任务一（11）！" + "\n");
                }));
                for (int i = 0; i < 10; i++)
                {
                    ThrowException("任务一（11）", i);
                }
                return 0;
            });

            try
            {
                tt11.Wait();
            }catch(Exception ex)
            {
               
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    tb1.AppendText("任务一(11)中的所有异常已被处理！" + "\n");
                    _watch11.Stop();
                    tb1.AppendText("这是任务一，使用Wait()的方法捕捉线程：" + _watch11.Elapsed.ToString() + "毫秒！\n");
                    _watch11.Reset();
                }));
            }
            //Task[] array = new Task[2];
            //Task task2 = Task.Factory.StartNew(() =>
            //{
            //    Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        tb1.AppendText("这是任务二！" + "\n");
            //    }));
            //    for (int i = 0; i < 10; i++)
            //    {
            //        ThrowException("任务二", i);
            //    }
            //});
            //array[0] = task2;
            //Task task3 = Task.Factory.StartNew(() =>
            //{
            //    Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        tb1.AppendText("这是任务三！" + "\n");
            //    }));
            //    for (int i = 0; i < 10; i++)
            //    {
            //        ThrowException("任务三", i);
            //    }
            //});
            //array[1] = task3;

            //var taskArray = Task.WhenAll(array).ContinueWith(t =>
            //{
            //        //Console.WriteLine("捕捉到WhenAll并行的异常！");

            //        foreach (var item in t.Exception.Flatten().InnerExceptions)
            //    {
            //        Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            tb1.AppendText("捕捉到WhenAll并行的异常！Exception caught:" + item.Message + "\n");
            //        }));
            //    }


            //    t.Exception.Handle(ex =>
            //    {
            //        Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            tb1.AppendText("捕捉到WhenAll并行的异常！Exception caught:" + ex.Message + "\n");
            //        }));
            //        return true;
            //    });
            //        //Console.WriteLine("", t.Exception);

            //    }, TaskContinuationOptions.OnlyOnFaulted);


            //Task task4 = Task.Factory.StartNew(() =>
            //{
            //    Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        tb1.AppendText("这是任务四！" + "\n");
            //    }));
            //    for (int i = 0; i < 10; i++)
            //    {
            //        ThrowException("任务四", i);
            //    }
            //});
            //try
            //{
            //    task4.Wait();
            //}
            //catch (AggregateException ex)
            //{
            //    foreach (var item in ex.InnerExceptions)
            //    {
            //        //Console.WriteLine("使用对Wait()方法进行Try...Catch捕捉异常：{0}", item.Message);
            //        Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            tb1.AppendText("使用对Wait()方法进行Try...Catch捕捉异常：" + item.Message + "\n");
            //        }));
            //    }
            //}
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb1.Clear();
            bt1.IsEnabled = false;
 
           SetMultiTask();
               
           bt1.IsEnabled = true;
                
  
          
        }
    }

    public class ParallelOption
    {
       
    }
}
