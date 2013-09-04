using System;

namespace NetAtomic
{
    public abstract class AtomicIntegerBase : AtomicBase<int>
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
            return update(x => x + value);
        }

        protected int add(Func<int, int> updateFunc)
        {
            return update(x => x + updateFunc(x));
        }
    }
}