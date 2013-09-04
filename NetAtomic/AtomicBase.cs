using System;
using System.Threading;

namespace NetAtomic
{
    public class AtomicBase<TValue>
    {
        private readonly object _valueLock = new object();

        public AtomicBase()
        {
        }

        public AtomicBase(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; protected set; }

        protected TValue update(Func<TValue, TValue> updateFunc)
        {
            lock (_valueLock)
            {
                Value = updateFunc(Value);
                return Value;
            }
        }

        protected bool tryUpdate(Func<TValue, TValue> updateFunc)
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
    }
}