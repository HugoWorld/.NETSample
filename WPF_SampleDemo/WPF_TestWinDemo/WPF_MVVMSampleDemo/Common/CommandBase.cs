using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;


namespace WPF_MVVMSampleDemo.Common
{
    public class CommandBase: ICommand
    {
        private readonly Action<object> _ExecuteMethod = null;
        private readonly  Func<object, bool> _canExecuteMethod = null;

        /// <summary>
        /// 继承ICommand接口中的CanExecuteChanged事件
        /// </summary>
        public event EventHandler CanExecuteChanged;

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandBase(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");
            _ExecuteMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public CommandBase(Action<object> executeMethod)
        {
            _ExecuteMethod = executeMethod;
        }

        public CommandBase(Action executeMethod)
        {
            _ExecuteMethod = delegate (object o) { executeMethod(); };
        }
  
        /// <summary>
        /// 封装内部Execute（T parameter）函数，并继承ICommand接口中的Execute方法
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (_ExecuteMethod != null)
            {
                _ExecuteMethod(parameter);
            }
        }

        /// <summary>
        /// 封装内部CanExecute（T parameter）函数，并继承ICommand接口中的CanExecute方法
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(object).IsValueType)
            {
                return (_canExecuteMethod == null);
            }
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;
        }
      
       
    }
}
