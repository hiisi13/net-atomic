namespace NetAtomic
{
    public class AtomicCounter : AtomicIntegerBase
    {
        private readonly int _step;

        public AtomicCounter(int initialValue, int step = 1): base(initialValue)
        {
            _step = step;
        }

        public int Next()
        {
            return add(_step);
        }
    }
}