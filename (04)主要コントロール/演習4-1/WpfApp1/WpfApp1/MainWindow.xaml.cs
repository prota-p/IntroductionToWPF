using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ロゴ画像のパスを設定
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "images/logo.png");
            LogoImage.Source = new BitmapImage(new Uri(path));
        }

        // イベントハンドラ: ボタンがクリックされたときに呼び出される
        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            // TextBox: 入力されたメモを取得
            string memo = MemoTextBox.Text;

            // ComboBox: 選択されたカテゴリを取得
            string? category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrWhiteSpace(memo))
            {
                // ListView: 新しいメモを追加
                MemoListView.Items.Add($"{memo} ({category})");

                // TextBox: 入力欄をクリア
                MemoTextBox.Clear();
            }
        }
    }
}