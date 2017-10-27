using System.Collections.Generic;
using System.Linq;

namespace testFirst
{
    public class Game
    {
        public List<Frame> Frames { get; set; }
        public int[] Throws = new int[21];
        public int Score { get; set; }

        public Game()
        {
            Frames = new List<Frame>();
        }

        public int GetScore()
        {
            return ScoreForFrame(GetCurrentFrame() - 1);
        }

        public void Add(int pins)
        {
            Score += pins;
            AdjustCurrentFrame();
        }

        public int ScoreForFrame(int frame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < frame; currentFrame++)
            {
                int firstThrow = Throws[ball++];
                int secondThrow = Throws[ball++];
                int frameScore = firstThrow + secondThrow;
                // spare needs next frames first throw
                if (frameScore == 10)
                    score += frameScore + Throws[ball];
                else
                {
                    score += frameScore;
                }
            }
            return score;
        }

        public void AdjustCurrentFrame()
        {
            if (FirstThrow)
            {
                FirstThrow = false;
            }
            else
            {
                FirstThrow = true;
                CurrentFrame++;
            }
        }

        public int GetCurrentFrame()
        {
            return CurrentFrame;
        }
    }
}