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

            Console.WriteLine($"Welcome, {player1.Name}. Get ready to bowl!");

        }

        
    }

    class Player
    {
        public string Name { get; set; } 
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public int Bowl()
        {
            return RandomScoreCalculator.PinsDown();
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
