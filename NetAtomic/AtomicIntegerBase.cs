using System;

namespace NetAtomic
{
    public abstract class AtomicIntegerBase : Atomic<int>
    {
        protected AtomicIntegerBase()
        {
        }

        protected AtomicIntegerBase(int value)
            : base(value)
        {
        }

        protected int add(int value)
        {
            return Update(x => x + value);
        }

        protected int add(Func<int, int> updateFunc)
        {
            return Update(x => x + updateFunc(x));
        }
    }
}