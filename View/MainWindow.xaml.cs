using Calc_MVVM.ViewModel;
using System.Windows;

namespace Calc_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel_MainWindow VM = new ViewModel_MainWindow();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
            CommandBindings.Add(VM.binding);
        }
    }
}