using NUnit.Framework;

namespace refactorfun_bowling
{
    [TestFixture]
    public class FrameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestScoreNoThrows()
        {
            var f = new Frame();
            Assert.AreEqual(0, f.Score());
        }

        [Test]
        public void TestAddOeThrow()
        {
            var f = new Frame();
            f.Add(5);
            Assert.AreEqual(5, f.Score());
        }
    }
}