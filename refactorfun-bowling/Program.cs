using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorfun_bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowling!!!");
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();
            var player1 = new Player(name);
            var game = new Game(new List<Player> { player1 });
            var scoreBoard = new ScoreBoard();

            Console.WriteLine($"Welcome, {player1.Name}. Get ready to bowl!");
            scoreBoard.PrintScoreBoard();
            do
            {
                Console.WriteLine("Player 1 is up:");
                var score = game.EvaluateThrow(player1, game.Frame, player1.Bowl());
                player1.Score += Int32.Parse(score);
                Console.WriteLine($"{player1.Name}'s first throw yeilded a score of {score}");
                Console.ReadKey();
            } while (game.Frame < 10);
        }
    }

    class Game
    {
        public int Frame { get; set; }
        public List<Player> Players { get; set; }

        public Game(List<Player> players)
        {
            Frame = 0;
            Players = players;
        }

        public string EvaluateThrow(Player player, int frame, int score)
        {
            if (score < 10 && !player.Frames[frame].HasThrown)
            {
                player.Score += score;
                player.Frames[frame].ThrowOne = score;
                return $"{score}";
            }
            if (score < 10 && player.Frames[frame].HasThrown)
            {
                if (score + player.Frames[frame].ThrowOne == 10)
                {
                    player.Frames[frame].ThrowTwo = score;
                    return "spare";
                }

                player.Frames[frame].ThrowTwo = score;
                return $"{score + player.Frames[frame].ThrowOne}";
            }
            return "strike";
        }
    }

    class ScoreBoard
    {
        public void PrintScoreBoard()
        {
            Console.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+");
            Console.WriteLine("|    1     |     2    |     3    |     4    |     5    |     6    |    7     |     8    |     9    |    10    |");
            Console.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+");
            Console.WriteLine("|    |     |    |     |    |     |    |     |    |     |    |     |    |     |    |     |    |     |   |   |  |");
            Console.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+");
            Console.WriteLine("|          |          |          |          |          |          |          |          |          |          |");
            Console.WriteLine("+----------+----------+----------+----------+----------+----------+----------+----------+----------+----------+");
        }

        public void RecordScore(int frame, int throwOne, int throwTwo)
        {

        }
    }

    class Player
    {
        public string Name { get; set; }
        public List<Frame> Frames { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Frames = new List<Frame>
            {
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
            };
            Score = 0;
        }

        public int Bowl()
        {
            var pinsHit = RandomScoreCalculator.PinsDown();
            Console.WriteLine($"Pins hit: {pinsHit}");
            return pinsHit;
        }
    }

    class Frame
    {
        public int ThrowOne { get; set; }
        public int ThrowTwo { get; set; }
        public bool HasThrown { get; set; }

        public Frame()
        {
            HasThrown = false;
        }

        public void SetHasThrown()
        {
            HasThrown = !HasThrown;
        }
    }

    class RandomScoreCalculator
    {
        public static int PinsDown()
        {
            return new Random().Next(1, 11);
        }
    }
}
