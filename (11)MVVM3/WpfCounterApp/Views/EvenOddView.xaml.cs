using System.Windows.Controls;
using WpfCounterApp.ViewModels;

namespace WpfCounterApp.Views
{
    /// <summary>
    /// EvenOddView.xaml の相互作用ロジック
    /// </summary>
    public partial class EvenOddView : UserControl
    {
        public EvenOddView()
        {
            InitializeComponent();
        }

        public void SetViewModel(EvenOddViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
