using System.Windows;
using WpfCounterApp.Models;
using WpfCounterApp.Services;
using WpfCounterApp.ViewModels;
using WpfCounterApp.Views;

namespace WpfCounterApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // サービスを作成
            var storage = new JsonCounterStorage();

            // Modelを作成
            var model = new CounterModel();

            // ViewModelを作成（依存性注入）
            var counterViewModel = new CounterViewModel(model, storage);
            var evenOddViewModel = new EvenOddViewModel(model);

            // ★MainViewModelを作成（ViewModelの階層構造を構築）
            var mainViewModel = new MainViewModel(counterViewModel, evenOddViewModel);

            // ★MainWindowを作成し、MainViewModelをDataContextに設定
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };

            // ウィンドウを表示
            mainWindow.Show();
        }
    }
}
