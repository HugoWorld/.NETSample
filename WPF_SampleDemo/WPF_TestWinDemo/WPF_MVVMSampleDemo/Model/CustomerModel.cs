using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVMSampleDemo.Model
{

    public class Customer
    {
        private string _name;

        public string CustomerName
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }


        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (value > 0)
                {
                    _amount = value;
                }
                else
                {
                    _amount = 0;
                }
            }
        }

        private double _Tax;
        public double Tax
        {
            get { return _Tax; }
        }


        private string _married = "";

        public MarriedStatus Married
        {
            get
            {
                if (_married == "Married" || _married == "Single")
                {
                    return (MarriedStatus) Enum.Parse(typeof (MarriedStatus), _married.ToString());
                }
                else
                {
                    return MarriedStatus.None;
                }
            }
            set
            {
                _married = Enum.GetName(typeof (MarriedStatus), value);
            }
        }

        public void CalculateTax()
        {
            if (_amount > 2000)
            {
                _Tax = 20;
            }
            else if (_amount > 1000)
            {
                _Tax = 10;
            }
            else
            {
                _Tax = 5;
            }
        }
    }


    public enum MarriedStatus
    {
        None=0,
        Married=1,
        Single
    }
}
