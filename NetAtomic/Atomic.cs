using System;

namespace NetAtomic
{
    public class Atomic<TValue> : AtomicBase<TValue>
    {
        public Atomic()
        {
        }
        
        public Atomic(TValue value) : base(value)
        {
        }

        public TValue Update(Func<TValue, TValue> updateFunc)
        {
            return update(updateFunc);
        }

        public TValue Update(TValue value)
        {
            return update(x => value);
        }

        public bool TryUpdate(Func<TValue, TValue> updateFunc)
        {
            return tryUpdate(updateFunc);
        }

        public bool TryUpdate(TValue value)
        {
            return tryUpdate(x => value);
        }
    }
}
