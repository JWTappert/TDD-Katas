using System;
using System.Collections.Generic;
using System.Linq;

namespace testFirst
{
    public class Game
    {
        public int[] Throws = new int[21];
        public int CurrentThrow;
        public int CurrentFrame = 1;
        public int Score { get; set; }
        public bool FirstThrow = true;

        public int GetScore()
        {
            return ScoreForFrame(GetCurrentFrame() - 1);
        }

        public void Add(int pins)
        {
            Throws[CurrentThrow++] = pins;
            Console.WriteLine($"Throws[{CurrentThrow}]: {Throws[CurrentThrow - 1]} Pins: {pins}");
            Score = ScoreForFrame(CurrentFrame);
            AdjustCurrentFrame(pins);
        }

        public int ScoreForFrame(int frame)
        {
            int ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < frame; currentFrame++)
            {
                Console.WriteLine(ball);
                int firstThrow = Throws[ball];

                if (firstThrow == 10)
                {
                    score += 10 + Throws[ball] + Throws[ball + 1];
                    ball += 1;
                }
                else
                {
                    ball = MoveToNextBall(ball);
                    int secondThrow = Throws[ball];
                    int frameScore = firstThrow + secondThrow;
                    // spare needs next frames first throw
                    if (frameScore == 10)
                        score += frameScore + Throws[ball];
                    else
                    {
                        score += frameScore;
                    }
                }
            }
            return score;
        }

        private static int MoveToNextBall(int ball)
        {
            ball += 1;
            return ball;
        }

        public void AdjustCurrentFrame(int pins)
        {
            if (FirstThrow)
            {
                if (pins == 10) //STRIKE!
                    CurrentFrame++;
                else
                {
                    FirstThrow = false;
                }
                FirstThrow = false;
            }
            else
            {
                FirstThrow = true;
                CurrentFrame++;
            }
            CurrentFrame = Math.Min(11, CurrentFrame);
        }

        public int GetCurrentFrame()
        {
            return CurrentFrame;
        }
    }
}