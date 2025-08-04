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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // データオブジェクトを作成
            var person = new Person
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

            // 1. Window全体にPersonを設定
            this.DataContext = person;
            // → この時点で、すべての子コントロールがPersonを参照

            // 2. 特定のコントロールに別のデータを設定
            CompanyGroup.DataContext = company;
            // → CompanyGroup内のコントロールだけがCompanyを参照
            // → 他の部分は引き続きPersonを参照
        }
    }

    // データクラス
    public class Person
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Job { get; set; }
    }

    public class Company
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
    }
}