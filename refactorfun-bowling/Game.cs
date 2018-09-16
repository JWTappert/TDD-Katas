using System.Runtime.InteropServices;

namespace refactorfun_bowling
{
    public class Game
    {
        private int _currentFrame;
        private bool _isFirstThrow;
        private readonly Scorer _scorer = new Scorer();

        public Game()
        {
            _isFirstThrow = true;
            _currentFrame = 1;
        }

        public int Score()
        {
            return ScoreForFrame(_currentFrame);
        }

        public void Add(int pins)
        {
            _scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        public int ScoreForFrame(int theFrame)
        {
            return _scorer.ScoreForFrame(theFrame);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBllInFrme(pins))
                AdvanceFrame();
            else
                _isFirstThrow = false;
        }

        private bool LastBllInFrme(int pins)
        {
            return Strike(pins) || (!_isFirstThrow);
        }

        private bool Strike(int pins)
        {
            return (_isFirstThrow && pins == 10);
        }

        private void AdvanceFrame()
        {
            _currentFrame++;
            if (_currentFrame > 10)
                _currentFrame = 10;
        }
    }
}