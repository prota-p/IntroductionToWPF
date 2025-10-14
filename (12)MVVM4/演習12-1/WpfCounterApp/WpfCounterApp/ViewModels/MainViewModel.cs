namespace WpfCounterApp.ViewModels
{
    public class MainViewModel
    {
        public CounterViewModel CounterViewModel { get; }
        public EvenOddViewModel EvenOddViewModel { get; }

        public MainViewModel(CounterViewModel counterViewModel, EvenOddViewModel evenOddViewModel)
        {
            CounterViewModel = counterViewModel;
            EvenOddViewModel = evenOddViewModel;
        }
    }
}