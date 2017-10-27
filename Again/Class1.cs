using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Again
{
    public class Class1
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }
        [Test]
        public void CanHaveADeadGame()
        {
            for (int i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }

            _game.Score().Should().Be(0);
        }

        [Test]
        public void CanRollAOnePointGame()
        {
            _game.Roll(1);
            for (int i = 0; i < 19; i++)
            {
                _game.Roll(0);
            }

            _game.Score().Should().Be(1);
        }

        [Test]
        public void CanRollAllOnes()
        {
            for (int i = 0; i < 20; i++)
            {
                _game.Roll(1);
            }

            _game.Score().Should().Be(20);
        }

        [Test]
        public void CanRollASpare()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            for (int i = 0; i < 17; i++)
            {
                _game.Roll(0);
            }

            _game.Score().Should().Be(20);
        }

        [Test]
        public void CanRollTwoSpares()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(5);
            for (int i = 0; i < 15; i++)
            {
                _game.Roll(0);
            }

            _game.Score().Should().Be(35);
        }

        [Test]
        public void CanRollAStriek()
        {
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(3);
            for (int i = 0; i < 16; i++)
            {
                _game.Roll(0);
            }

            _game.Score().Should().Be(26);
        }
    }

    public class Game
    {
        public List<int> Rolls = new List<int>();

        public void Roll(int pinsKnockedOverOnRoll)
        {
            Rolls.Add(pinsKnockedOverOnRoll);
        }

        private bool ASpare(int currentBallIndex)
        {
            return Rolls[currentBallIndex - 1] + Rolls[currentBallIndex - 2] == 10;
        }

        public int Score()
        {
            var currentScore = 0;
            for (int i = 0; i < 21; i++)
            {
                if (i >= 2)
                {

                }
            }
            return Rolls.Sum();
        }
    }

    public class Frame
    {
        public int BallOne { get; set; }
        public int BallTwo { get; set; }
        public int BallThree { get; set; }
        public bool BallOneDone { get; set; }
        public bool BallTwoDone { get; set; }
        public int ScoreForFrame { get; set; }
        public bool IsStrike { get; set; }
    }
}
