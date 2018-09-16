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
        private int _firstThrow;
        private int _secondThrow;

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
                _firstThrow = _throws[_ball++];
                if (_firstThrow == 10)
                {
                    score += 10 + _throws[_ball] + _throws[_ball + 1];
                }
                else
                {
                    score += HandleSecodThrow();
                }
            }

            return score;
        }

        private int HandleSecodThrow()
        {
            var score = 0;
            _secondThrow = _throws[_ball++];
            var frameScore = _firstThrow + _secondThrow;
            if (frameScore == 10)
            {
                score += frameScore + _throws[_ball];
            }
            else
            {
                score += frameScore;
            }

            return score;
        }

        public int CurrentFrame()
        {
            return _currentFrame;
        }
    }
}