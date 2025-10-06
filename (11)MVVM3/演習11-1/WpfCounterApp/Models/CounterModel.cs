namespace WpfCounterApp.Models
{
    public class CounterModel
    {
        public int Value { get; private set; }
        public event Action? ValueChanged;

        public CounterModel(int initialValue = 0)
        {
            Value = initialValue;
        }

        private void Notify() => ValueChanged?.Invoke();

        public void SetValue(int value)
        {
            Value = value;
            Notify();
        }

        public void Increment()
        {
            Value++;
            Notify();
        }

        public void Decrement()
        {
            if (!CanDecrement()) return;
            Value--;
            Notify();
        }

        public bool CanDecrement()
        {
            return Value > 0;
        }
    }
}
