using NUnit.Framework;

namespace refactorfun_bowling
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TestOneThrow()
        {
            _game.Add(5);
            Assert.AreEqual(5, _game.Score());
            Assert.AreEqual(1, _game.CurrentFrame());
        }

        [Test]
        public void TestTwoThrows()
        {
            _game.Add(5);
            _game.Add(4);
            Assert.AreEqual(9, _game.Score());
            Assert.AreEqual(2, _game.CurrentFrame());
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            _game.Add(5);
            _game.Add(4);
            _game.Add(7);
            _game.Add(2);
            
            Assert.AreEqual(18, _game.Score());
            Assert.AreEqual(9, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            Assert.AreEqual(3, _game.CurrentFrame());
        }

        [Test]
        public void TestSimpleSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            Assert.AreEqual(2, _game.CurrentFrame());
        }

        [Test]
        public void TestSimpleFrameafterSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            Assert.AreEqual(3, _game.CurrentFrame());
            
        }
    }
}