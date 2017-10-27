using System.Collections.Generic;
using System.Linq;

namespace testFirst
{
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