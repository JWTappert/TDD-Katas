using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
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
            Console.WriteLine("Test 1");
            _game.Add(5);
            _game.Add(4);
            _game.Score.Should().Be(9);
            _game.GetCurrentFrame().Should().Be(2);
        }

        [Test]
        public void TestFourThrows()
        {
            Console.WriteLine("Test 2");
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
            Console.WriteLine("Test 3");
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.ScoreForFrame(1).Should().Be(13);
            _game.GetCurrentFrame().Should().Be(2);
        }

        [Test]
        public void SimpleFrameAfterSpare()
        {
            Console.WriteLine("Test 4");
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);

            _game.ScoreForFrame(1).Should().Be(13);
            _game.ScoreForFrame(2).Should().Be(18);
            _game.Score.Should().Be(18);
            _game.GetCurrentFrame().Should().Be(3);
        }

        [Test]
        public void SimpleStrike()
        {
            Console.WriteLine("Test 5");
            _game.Add(10);
            _game.Add(3);
            _game.Add(6);

            _game.ScoreForFrame(1).Should().Be(19);
            _game.GetScore().Should().Be(28);
            _game.GetCurrentFrame().Should().Be(3);
        }

        [Test]
        public void TestPerfectGame()
        {
            Console.WriteLine("Test 6");
            for (int i = 0; i < 11; i++)
            {
                _game.Add(10);
            }
            _game.Score.Should().Be(300);
            _game.GetCurrentFrame().Should().Be(11);
        }

        [Test]
        public void TestEndOfArray()
        {
            Console.WriteLine("Test 7");
            for (int i = 0; i < 9; i++)
            {
                _game.Add(0);
                _game.Add(0);
            }
            _game.Add(2);
            _game.Add(8);
            _game.Add(10);
            _game.Score.Should().Be(20);
        }

        [Test]
        public void SampleGame()
        {
            Console.WriteLine("Test 8");
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
            _game.Add(2);
            _game.Score.Should().Be(135);
        }

        [Test]
        public void HeartBreaker()
        {
            Console.WriteLine("Test 9");
            for (int i = 0; i < 10; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            _game.Score.Should().Be(299);
        }

        [Test]
        public void TenthFrameSpare()
        {
            Console.WriteLine("Test 10");
            for (int i = 0; i < 10; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            _game.Add(1);
            _game.Add(1);
            _game.Score.Should().Be(270);
        }
    }
}