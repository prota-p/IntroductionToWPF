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
        private readonly JsonCounterStorage _storage; //★追加
        private readonly SimpleCommand _incrementCommand;
        private readonly SimpleCommand _decrementCommand;

        public CounterViewModel()
        {
            //★起動時、カウンター値を読み込む
            _storage = new JsonCounterStorage(); 
            int initialValue = _storage.Load(); 
            _model = new CounterModel(initialValue);

            _incrementCommand = new SimpleCommand(_ => ExecuteIncrement());
            _decrementCommand = new SimpleCommand(_ => ExecuteDecrement(), _ => _model.CanDecrement());
        }

        public int Count => _model.Value;

        public ICommand IncrementCommand => _incrementCommand;
        public ICommand DecrementCommand => _decrementCommand;

        private void ExecuteIncrement()
        {
            _model.Increment();
            OnPropertyChanged(nameof(Count));
            _storage.Save(_model.Value); //★変更後の値を保存
        }

        private void ExecuteDecrement()
        {
            _model.Decrement();
            OnPropertyChanged(nameof(Count));
            _storage.Save(_model.Value); //★変更後の値を保存
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