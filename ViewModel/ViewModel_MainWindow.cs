using Calc_MVVM.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Calc_MVVM.ViewModel
{
    class ViewModel_MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> OperationsList { get; } = Operations.operationsList;
        public List<char> OperationList { get; } = Operations.operationList;
        private byte index;

        public byte Operations_SelectedIndex
        {
            set
            {
                index = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Operations_SelectedItem"));
                PropertyChanged(this, new PropertyChangedEventArgs("Operation_SelectedItem"));
            }
        }

        public string Operations_SelectedItem
        {
            get { return OperationsList[index]; }
        }

        public char Operation_SelectedItem
        {
            get { return OperationList[index]; }
        }

        public double A
        {
            get { return Maths.a; }
            set { Maths.a = value; }
        }

        public double B
        {
            get { return Maths.b; }
            set { Maths.b = value; }
        }

        public double Sum
        {
            get { return Maths.a + Maths.b; }
        }

        public double Sub
        {
            get { return Maths.a - Maths.b; }
        }

        public double Mul
        {
            get { return Maths.a * Maths.b; }
        }

        public double Del
        {
            get { return Maths.a / Maths.b; }
        }

        public double Result
        {
            get { return Maths.result; }
            set { Maths.result = 0; }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (index == 0)
            {
                Maths.result = Sum;
            }
            if (index == 1)
            {
                Maths.result = Sub;
            }
            if (index == 2)
            {
                Maths.result = Mul;
            }
            if (index == 3)
            {
                Maths.result = Del;
            }

            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }

        public CommandBinding binding;

        public ViewModel_MainWindow()
        {
            binding = new CommandBinding(Command);
            binding.Executed += CommandExecuted;
        }
    }
}