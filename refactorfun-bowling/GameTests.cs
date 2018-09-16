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
        public void TestTwoThrows()
        {
            _game.Add(5);
            _game.Add(4);
            Assert.AreEqual(9, _game.Score());
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
        }

        [Test]
        public void TestSimpleSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
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
            Assert.AreEqual(18, _game.Score());
        }

        [Test]
        public void TestSimpleStrike()
        {
            _game.Add(10);
            _game.Add(6);
            _game.Add(3);
            Assert.AreEqual(19, _game.ScoreForFrame(1));
            Assert.AreEqual(28, _game.Score());
        }

        [Test]
        public void TestperfectGame()
        {
            for (var i = 0; i < 12; i++)
            {
               _game.Add(10); 
            }
            Assert.AreEqual(300, _game.Score());
        }

        [Test]
        public void TestEndOfArray()
        {
            for (var i = 0; i < 9; i++)
            {
                _game.Add(0);
                _game.Add(0);
            }
            _game.Add(2);
            _game.Add(8);
            _game.Add(10);
            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void TestSampleGame()
        {
            _game.Add(1);
            _game.Add(4);
            _game.Add(4);
            _game.Add(5);
            _game.Add(6);
            _game.Add(4);
            _game.Add(5);
            _game.Add(5);
            _game.Add(10);
            _game.Add(0);
            _game.Add(1);
            _game.Add(7);
            _game.Add(3);
            _game.Add(6);
            _game.Add(4);
            _game.Add(10);
            _game.Add(2);
            _game.Add(8);
            _game.Add(6);
            Assert.AreEqual(133, _game.Score());
        }

        [Test]
        public void TestHeartBreak()
        {
            for (var i = 0; i < 11; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            Assert.AreEqual(299, _game.Score());
        }

        [Test]
        public void TestTenthFrameSpare()
        {
            for (var i = 0; i < 9; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            _game.Add(1);
            _game.Add(1);
            Assert.AreEqual(270, _game.Score());
        }
    }
}