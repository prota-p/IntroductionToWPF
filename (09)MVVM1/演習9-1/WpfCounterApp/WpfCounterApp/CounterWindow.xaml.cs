using System.Windows;

namespace WpfCounterApp
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
