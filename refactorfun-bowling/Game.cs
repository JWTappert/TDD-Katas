using System.Runtime.InteropServices;

namespace refactorfun_bowling
{
    public class Game
    {
        private int _score;
        private int _currentThrow;
        private int _currentFrame;
        private readonly int[] _throws = new int[21];
        private bool _isFirstThrow;
        private int _ball;

        public Game()
        {
            _isFirstThrow = true;
            _currentFrame = 1;
        }

        public double Score()
        {
            return ScoreForFrame(_currentFrame - 1);
        }

        public void Add(int pins)
        {
            _throws[_currentThrow++] = pins;
            _score += pins;

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (_isFirstThrow)
            {
                if (pins == 10)
                {
                    _currentFrame++;
                }
                else
                {
                    _isFirstThrow = false;
                }
            }
            else
            {
                _isFirstThrow = true;
                _currentFrame++;
            }

            if (_currentFrame > 11)
            {
                _currentFrame = 11;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            _ball = 0;
            var score = 0;
            for (var currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike;
                    _ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBallForSpare;
                    _ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    _ball += 2;
                }
            }

            return score;
        }

        private int NextTwoBallsForStrike => _throws[_ball + 1] + _throws[_ball + 2];

        private int NextBallForSpare => _throws[_ball + 2];
        
        private int TwoBallsInFrame => _throws[_ball] + _throws[_ball + 1];


        private bool Strike()
        {
            return _throws[_ball] == 10;
        }

        private bool Spare()
        {
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }

        public int CurrentFrame()
        {
            return _currentFrame;
        }
    }
}