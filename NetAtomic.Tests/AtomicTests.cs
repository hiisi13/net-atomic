using System.Threading;
using NUnit.Framework;

namespace NetAtomic.Tests
{
    [TestFixture]
    public class AtomicTests
    {
        [Test]
        public void ParameterlessConstructorShouldInitDefaultValue()
        {
            var atomicString = new Atomic<string>();
            Assert.IsNull(atomicString.Value);

            var atomicInt = new Atomic<int>();
            Assert.AreEqual(0, atomicInt.Value);
        }

        [Test]
        public void ConstructorShouldSetSpecifiedValue()
        {
            const string atomicStringValue = "this is atomic value";
            var atomicString = new Atomic<string>(atomicStringValue);
            Assert.AreEqual(atomicStringValue, atomicString.Value);

            const int atomicIntValue = 100;
            var atomicInt = new Atomic<int>(atomicIntValue);
            Assert.AreEqual(atomicIntValue, atomicInt.Value);
        }

        [Test]
        public void ShouldUpdateValue()
        {
            var atomic = new Atomic<int>(100);
            const int expected = 110;
            int actual = atomic.Update(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldCallUpdateFunction()
        {
            bool called = false;
            var atomic = new Atomic<int>(100);
            atomic.Update(x =>
                {
                    called = true;
                    return x;
                });
            Assert.True(called);
        }

        [Test]
        public void ShouldUpdateUsingFunction()
        {
            var atomic = new Atomic<int>();
            const int expected = 100;
            int actual = atomic.Update(x => x + expected);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, atomic.Value);
        }

        [Test]
        public void ShouldTryAndUpdate()
        {
            var atomic = new Atomic<int>(100);
            const int expected = 110;
            bool success = atomic.TryUpdate(expected);
            Assert.True(success);
            Assert.AreEqual(expected, atomic.Value); 
        }

        [Test]
        public void ShouldTryAndUpdateUsingFunction()
        {
            var atomic = new Atomic<int>(0);
            const int expected = 100;
            bool success = atomic.TryUpdate(x => x + expected);
            Assert.True(success);
            Assert.AreEqual(expected, atomic.Value);
        }

        [Test]
        public void ConcurrentUpdateShouldFail()
        {
            var atomic = new Atomic<int>();
            var result = false;
            atomic.Update(x =>
                {
                    var thread = new Thread(() => result = atomic.TryUpdate(100));
                    thread.Start();
                    return x;
                });
            Assert.False(result);
        }
    }
}
