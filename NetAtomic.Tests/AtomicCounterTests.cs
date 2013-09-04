using NUnit.Framework;

namespace NetAtomic.Tests
{
    [TestFixture]
    public class AtomicCounterTests
    {
        [Test]
        public void ShouldIncrementByDefaultStep()
        {
            var counter = new AtomicCounter(1);
            int actual = counter.Next();
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void ShouldIncrementBySpecifiedStep()
        {
            var counter = new AtomicCounter(1, 100);
            int actual = counter.Next();
            Assert.AreEqual(101, actual);
        }
    }
}