using System.Windows.Controls;
using WpfCounterApp.ViewModels;

namespace WpfCounterApp.Views
{
    /// <summary>
    /// CounterView.xaml の相互作用ロジック
    /// </summary>
    public partial class CounterView : UserControl
    {
        public CounterView()
        {
            InitializeComponent();
        }

        public void SetViewModel(CounterViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
