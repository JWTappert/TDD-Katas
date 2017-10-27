namespace testFirst
{
    public class Frame
    {
        public int Score { get; set; }
        public bool Completed { get; set; }
        public int Balls { get; set; }
        public bool Strike { get; set; }

        public int GetScore()
        {
            return Score;
        }

        public bool FrameIsCompleted()
        {
            if (Balls <= 2) return false;
            Completed = true;
            return Completed;
        }

        public void AddThrow(int pins)
        {
            Balls++;
            if (FrameIsCompleted())
            {
                Score = Score;
            }
            else
            {
                Score += pins;
            }
        }
    }
}