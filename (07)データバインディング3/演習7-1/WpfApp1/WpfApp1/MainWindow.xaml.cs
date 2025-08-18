using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly Person person; // フィールドに変更（後でアクセスするため）

        public MainWindow()
        {
            InitializeComponent();

            // データオブジェクトを作成
            person = new Person
            {
                Name = "田中太郎",
                Age = 30,
                Job = "ソフトウェアエンジニア"
            };

            var company = new Company
            {
                Name = "株式会社サンプル",
                Department = "開発部"
            };

            // DataContextを設定
            this.DataContext = person;
            CompanyGroup.DataContext = company;
        }

        // ボタンクリックのイベントハンドラー（次の手順で実装）
        private void OnDecrementAge(object sender, RoutedEventArgs e)
        {
            // 年齢を1減らす
            person.Age--;
        }

        private void OnIncrementAge(object sender, RoutedEventArgs e)
        {
            // 年齢を1増やす
            person.Age++;
        }
    }

    // INotifyPropertyChangedを実装したPersonクラス
    public class Person : INotifyPropertyChanged
    {
        private string _name = "";
        private int _age;
        private string _job = "";

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();// プロパティ変更を通知
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(); // プロパティ変更を通知
            }
        }

        public string Job
        {
            get => _job;
            set
            {
                _job = value;
                OnPropertyChanged();// プロパティ変更を通知
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // CallerMemberName属性を使った通知メソッド
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Companyクラスは変更なし
    public class Company
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
    }
}