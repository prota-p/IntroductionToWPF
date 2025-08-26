using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1
{
    public class Counter : INotifyPropertyChanged
    {
        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand IncrementCommand => _incrementCommand;
        public ICommand DecrementCommand => _decrementCommand;

        private readonly SimpleCommand _incrementCommand;
        private readonly SimpleCommand _decrementCommand;

        public Counter()
        {
            _incrementCommand = new SimpleCommand(_ => Count++);
            _decrementCommand = new SimpleCommand(_ => Count--, _ => Count > 0);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName == nameof(Count))
            {
                _decrementCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
