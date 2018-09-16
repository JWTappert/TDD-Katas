namespace refactorfun_bowling
{
    public class Scorer
    {
        private int _ball;
        private readonly int[] _throws = new int[21];
        private int _currentThrow; 
        
        public void AddThrow(int pins)
        {
            _throws[_currentThrow++] = pins;
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
        
        private bool Strike()
        {
            return _throws[_ball] == 10;
        }

        private bool Spare()
        {
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }

        private int NextTwoBallsForStrike => _throws[_ball + 1] + _throws[_ball + 2];

        private int NextBallForSpare => _throws[_ball + 2];
        
        private int TwoBallsInFrame => _throws[_ball] + _throws[_ball + 1];
    }
}