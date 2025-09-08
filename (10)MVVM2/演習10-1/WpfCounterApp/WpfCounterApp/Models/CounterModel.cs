namespace WpfCounterApp.Models
{
    public class CounterModel
    {
        public int Value { get; private set; }

        public CounterModel(int initialValue = 0)
        {
            Value = initialValue;
        }

        public void Increment()
        {
            Value++;
        }

        public bool CanDecrement()
        {
            return Value > 0;
        }

        public void Decrement()
        {
            if (CanDecrement())
            {
                Value--;
            }
        }
    }
}