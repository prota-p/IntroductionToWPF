namespace WpfCounterApp
{
    public class CounterModel
    {
        public int Value { get; private set; }

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