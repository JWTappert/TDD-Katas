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
        private Frame _frame;

        [SetUp]
        public void Setup()
        {
            _frame = new Frame();
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
    }
}