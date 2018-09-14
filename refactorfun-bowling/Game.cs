namespace refactorfun_bowling
{
    public class Game
    {
        private int _score;
        private int _currentThrow;
        private int _currentFrame;
        private readonly int[] _throws = new int[21];
        private bool _isFirstThrow;

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
            var ball = 0;
            var score = 0;
            for (var currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                var firstThrow = _throws[ball++];
                if (firstThrow == 10)
                {
                    score += 10 + _throws[ball] + _throws[ball + 1];
                }
                else
                {
                    var secondThrow = _throws[ball++];
                    var frameScore = firstThrow + secondThrow;
                    if (frameScore == 10)
                    {
                        score += frameScore + _throws[ball];
                    }
                    else
                    {
                        score += frameScore;
                    }
                }
            }

            return score;
        }

        public int CurrentFrame()
        {
            return _currentFrame;
        }
    }
}