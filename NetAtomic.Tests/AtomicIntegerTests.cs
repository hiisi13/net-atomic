using NUnit.Framework;

namespace NetAtomic.Tests
{
    [TestFixture]
    public class AtomicIntegerTests
    {
        [Test]
        public void ShouldAddToValue()
        {
            var atomicInt = new AtomicInteger();
            const int expected = 100;
            atomicInt.Add(expected);
            Assert.AreEqual(expected, atomicInt.Value);
        }

        [Test]
        public void ShouldAddToValueUsingFunction()
        {
            var atomicInt = new AtomicInteger();
            const int expected = 100;
            atomicInt.Add(x => expected);
            Assert.AreEqual(expected, atomicInt.Value);
        }
    }
}