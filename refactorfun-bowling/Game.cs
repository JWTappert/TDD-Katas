namespace refactorfun_bowling
{
    public class Game
    {
        private int _score;
        private int _currentThrow;
        private int _curentFrame;
        private readonly int[] _throws = new int[21];
        private bool _isFirstThrow;

        public Game()
        {
            _isFirstThrow = true;
            _curentFrame = 1;
        }

        public double Score()
        {
            return _score;
        }

        public void Add(int pins)
        {
            _throws[_currentThrow++] = pins;
            _score += pins;

            AdjustCurrentFrame();
        }

        private void AdjustCurrentFrame()
        {
            if (_isFirstThrow)
            {
                _isFirstThrow = false;
            }
            else
            {
                _isFirstThrow = true;
                _curentFrame++;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            var ball = 0;
            var score = 0;
            for (var currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                var firstThrow = _throws[ball++];
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

            return score;
        }

        public int CurrentFrame()
        {
            return _curentFrame;
        }
    }
}