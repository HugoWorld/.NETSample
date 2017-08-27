using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVMSampleDemo.Command;
using WPF_MVVMSampleDemo.Common;
using WPF_MVVMSampleDemo.Model;
using WPF_MVVMSampleDemo.Common;
using System.Windows;

namespace WPF_MVVMSampleDemo.ViewModel
{
    /***************************************************************************
    1. 类属性都以 UI 的命名方式来约定，这样看上去会更形象一些；
    2. 这个类负责了类型转换的代码，使得 UI 看上去更轻量级。例如代码中的“TxtAmount”属性。
       在 Model 类中的“Amount”属性是数字，而转换的过程是在 ViewModel 类中完成。
       换句话说这个类负责了 UI 显示的所有职责（译者注：逻辑上的业务职责）让 UI 后台代码看上去更简洁；
    3. 所有转换逻辑的代码都在这个类中，例如“LblAmountColor”属性和“IsMarried”属性；
    4. 所有的属性数据都保持了简单的字符类型，这样可以在大多 UI 技术平台上适用。
       例如，“LblAmountColor”属性把颜色值用字符串来传递，这样可以在任何 UI 类型中重用，同时我们也保持了最小的数据共性。
    **************************************************************************************************************/
    public class CustomerViewModel:NotifyObject
    {
        private Customer obj = new Customer();

        private ButtonCommand objCommand;
        
        public CustomerViewModel()
        {
            objCommand=new ButtonCommand(this);
        }
        /// <summary>
        /// 当执行CanExecuteCommand时设置的属性
        /// True：可以执行
        /// False：不能执行命令
        /// </summary>
        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                _canExecute = value;
                RaisePropertyChanged("CanExecute");
            }
        }
        public ICommand BtnClick
        {
            get { return objCommand; }
        }
        private CommandBase _calculatecommand;

        public CommandBase CalculateCommand
        {
            get
            {
                if(_calculatecommand==null)
                {
                    _calculatecommand = new CommandBase(new Action(obj.CalculateTax));
                }
                return _calculatecommand;
            }
        }


        private CommandBase _canExecuteCommand;

        public CommandBase CanExecuteCommand
        {
            get
            {
                if(_canExecuteCommand==null)
                {
                    _canExecuteCommand = new CommandBase(
                        new Action<object>(o => MessageBox.Show("命令可以执行！")),
                    new Func<object, bool>(o => CanExecute = true));
                }
                return _canExecuteCommand;
            }
        }

        private CommandBase _paramCommand;


        public void Calculate()
        {
            obj.CalculateTax();
        }
        public string TxtCustomerName
        {
            get { return obj.CustomerName; }
            set
            {
                obj.CustomerName = value;
                this.RaisePropertyChanged("TxtCustomerName");
            }
        }

        public string TxtAmount
        {
            get { return Convert.ToString(obj.Amount); }
            set
            {
                obj.Amount = Convert.ToDouble(value);
                this.RaisePropertyChanged("TxtAmount");
            }
        }

        public string LblAmountColor
        {
            get
            {
                if (obj.Amount > 2000)
                {
                    return "Blue";
                }
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }

        public bool IsMarried
        {
            get
            {
                if (obj.Married == MarriedStatus.Married)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
