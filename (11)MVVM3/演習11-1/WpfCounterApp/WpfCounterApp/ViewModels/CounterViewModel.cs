using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfCounterApp.Commands;
using WpfCounterApp.Models;
using WpfCounterApp.Services;

namespace WpfCounterApp.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private readonly CounterModel _model;
        private readonly JsonCounterStorage _storage;
        private readonly SimpleCommand _incrementCommand;
        private readonly SimpleCommand _decrementCommand;

        // ★コンストラクタで依存関係を受け取る
        public CounterViewModel(CounterModel model, JsonCounterStorage storage)
        {
            _model = model;
            _storage = storage;

            var initialValue = _storage.Load();
            _model.SetValue(initialValue); 

            // ★モデルの変更を購読
            _model.ValueChanged += OnCountChanged;

            _incrementCommand = new SimpleCommand(_ => ExecuteIncrement());
            _decrementCommand = new SimpleCommand(_ => ExecuteDecrement(), _ => _model.CanDecrement());
        }

        public int Count => _model.Value;

        public ICommand IncrementCommand => _incrementCommand;
        public ICommand DecrementCommand => _decrementCommand;

        private void ExecuteIncrement()
        {
            _model.Increment();
            _storage.Save(_model.Value);
        }

        private void ExecuteDecrement()
        {
            _model.Decrement();
            _storage.Save(_model.Value);
        }

        // ★Modelの変更通知を受け取る
        private void OnCountChanged()
        {
            OnPropertyChanged(nameof(Count));
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