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
        public void AddsScoreCorrectlyBetweenTwoFrames()
        {
            _game.Frames = new List<Frame>
            {
                new Frame {Completed = true, Score = 8},
                new Frame {Completed = true, Score = 8}
            };
            _game.GetScore().Should().Be(16);
        }

        [Test]
        public void DoesNotIncludeIncompleteFramesInScore()
        {
            _game.Frames = new List<Frame>
            {
                new Frame {Completed = true, Score = 8},
                new Frame {Completed = false, Score = 8}
            };
            _game.GetScore().Should().Be(8);
        }

        [Test]
        public void HandlesStrike()
        {
            _game.Frames = new List<Frame>
            {
                new Frame {Completed = true, Strike = true},
                new Frame {Completed = true, Score = 8},
            };
            _game.GetScore().Should().Be(26);
        }
    }
}