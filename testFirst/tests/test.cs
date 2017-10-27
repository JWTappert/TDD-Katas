using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Api;

namespace testFirst.tests
{
    [TestFixture]
    public class Test
    {
        private Game _game;
        private Frame _frame;

        [SetUp]
        public void Setup()
        {
            _frame = new Frame();
            _game = new Game();
        }

        [Test]
        public void ReturnNoThrowsScore()
        {
            _frame.GetScore().Should().Be(0);
        }

        [Test]
        public void ReturnsOneThrowScore()
        {
            _frame.AddThrow(5);
            _frame.GetScore().Should().Be(5);
        }

        [Test]
        public void ReturnsTwoThrowScore()
        {
            _frame.AddThrow(4);
            _frame.AddThrow(5);
            _frame.GetScore().Should().Be(9);
        }

        [Test]
        public void DoesNotAddScoreIfFrameIsCompleted()
        {
            _frame.Balls = 2;
            _frame.Score = 9;
            _frame.AddThrow(1);
            _frame.Score.Should().Be(9);
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

    public class Frame
    {
        public int Score { get; set; }
        public bool Completed { get; set; }
        public int Balls { get; set; }
        public bool Strike { get; set; }

        public int GetScore()
        {
            return Score;
        }

        public bool FrameIsCompleted()
        {
            if (Balls <= 2) return false;
            Completed = true;
            return Completed;
        }

        public void AddThrow(int pins)
        {
            Balls++;
            if (FrameIsCompleted())
            {
                Score = Score;
            }
            else
            {
                Score += pins;
            }
        }
    }

    public class Game
    {
        public List<Frame> Frames { get; set; }
        public int Score { get; set; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public int GetScore()
        {
            var completedFrames = Frames.Where(x => x.Completed);

            foreach (var completedFrame in completedFrames)
            {
                if (completedFrame.Strike)
                {
                    
                }
                Score += completedFrame.Score;
            }

            return Frames.Where(x => x.Completed).Sum(y => y.Score);
        }
    }
}