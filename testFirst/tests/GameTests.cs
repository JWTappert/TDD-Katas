using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace testFirst.tests
{
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TwoThrows()
        {
            _game.Add(5);
            _game.Add(4);
            _game.Score.Should().Be(9);
            _game.GetCurrentFrame().Should().Be(2);
        }

        [Test]
        public void TestFourThrows()
        {
            _game.Add(5);
            _game.Add(4);
            _game.Add(7);
            _game.Add(2);

            _game.Score.Should().Be(18);
            _game.ScoreForFrame(1).Should().Be(9);
            _game.ScoreForFrame(2).Should().Be(18);
            _game.GetCurrentFrame().Should().Be(3);
        }

        [Test]
        public void SimpleSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.ScoreForFrame(1).Should().Be(13);
            _game.GetCurrentFrame().Should().Be(2);
        }

        [Test]
        public void SimpleFrameAfterSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);

            _game.ScoreForFrame(1).Should().Be(13);
            _game.ScoreForFrame(2).Should().Be(18);
            _game.Score.Should().Be(18);
            _game.GetCurrentFrame().Should().Be(3);
        }
    }
}