using System;
using System.Threading;

namespace NetAtomic
{
    public class Atomic<TValue>
    {
        private readonly object _valueLock = new object();
        public TValue Value { get; private set; }
 
        public Atomic()
        {
        }
        
        public Atomic(TValue value)
        {
            Value = value;
        }

        public TValue Update(Func<TValue, TValue> updateFunc)
        {
            lock (_valueLock)
            {
                Value = updateFunc(Value);
                return Value;
            }
        }

        public TValue Update(TValue value)
        {
            return Update(x => value);
        }

        public bool TryUpdate(Func<TValue, TValue> updateFunc)
        {
            if (Monitor.TryEnter(_valueLock))
            {
                try
                {
                    Value = updateFunc(Value);
                    return true;
                }
                finally
                {
                    Monitor.Exit(_valueLock);
                }
            }
            return false;
        }

        public bool TryUpdate(TValue value)
        {
            return TryUpdate(x => value);
        }
    }
}
