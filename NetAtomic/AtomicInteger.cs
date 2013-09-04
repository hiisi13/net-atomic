using System;

namespace NetAtomic
{
    public class AtomicInteger : AtomicIntegerBase
    {
        public AtomicInteger()
        {
        }

        public AtomicInteger(int value)
            : base(value)
        {
        }

        public int Add(int value)
        {
            return add(value);
        }

        public int Add(Func<int, int> addFunc)
        {
            return add(addFunc);
        }
    }
}