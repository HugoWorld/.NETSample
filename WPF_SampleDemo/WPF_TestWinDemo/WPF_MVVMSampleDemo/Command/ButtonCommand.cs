using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVMSampleDemo.ViewModel;

namespace WPF_MVVMSampleDemo.Command
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private CustomerViewModel obj;

        public ButtonCommand(CustomerViewModel _obj)
        {
            obj = _obj;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            obj.Calculate();
        }
    }
}
