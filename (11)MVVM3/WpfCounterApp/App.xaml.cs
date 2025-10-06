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

            // 依存関係を設定（コンポジションルート）
            var storage = new JsonCounterStorage();

            // モデルを作成
            var model = new CounterModel();

            // ViewModelを作成（依存性注入）
            var counterViewModel = new CounterViewModel(model, storage);
            var evenOddViewModel = new EvenOddViewModel(model);

            // MainWindowを作成し、ViewModelを設定
            var mainWindow = new MainWindow();
            mainWindow.CounterView.SetViewModel(counterViewModel);
            mainWindow.EvenOddView.SetViewModel(evenOddViewModel);

            // ウィンドウを表示
            mainWindow.Show();
        }
    }
}
