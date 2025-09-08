using System.Windows;
using WpfCounterApp.ViewModels;

namespace WpfCounterApp.Views
{
    /// <summary>
    /// CounterWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CounterWindow : Window
    {
        public CounterWindow()
        {
            InitializeComponent();
            DataContext = new CounterViewModel();
        }
    }
}
