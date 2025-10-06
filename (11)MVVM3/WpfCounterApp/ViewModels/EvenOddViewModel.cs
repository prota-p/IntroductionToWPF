using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfCounterApp.Models;

namespace WpfCounterApp.ViewModels
{
    public class EvenOddViewModel : INotifyPropertyChanged
    {
        private readonly CounterModel _model;

        public EvenOddViewModel(CounterModel model)
        {
            _model = model;

            // ★モデルの変更を購読
            _model.ValueChanged += OnCountChanged;
        }

        public string EvenOddText => _model.Value % 2 == 0 ? "Even" : "Odd";

        private void OnCountChanged()
        {
            OnPropertyChanged(nameof(EvenOddText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}