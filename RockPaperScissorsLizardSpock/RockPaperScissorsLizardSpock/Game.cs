using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Game
    {
        Player playerOne;
        Player playerTwo;
        string playerOneName;
        string playerTwoName;
        List<string> rules;

        public Game()
        {
           rules = new List<string>()
            {
                "Scissors cuts Paper",
                "Paper covers Rock",
                "Rock crushes Lizard",
                "Lizard poisons Spock",
                "Spock smashes Scissors",
                "Scissors decapitates Lizard",
                "Lizard eats Paper",
                "Paper disproves Spock",
                "Spock vaporizes Rock",
                "Rock crushes Scissors"
            };
        }

        public void PlayGame()
        {
            DisplayIntro();
            DisplayRules(); 
            GetPlayer();
            StartPlay();
            GetWinner();
            PlayAgain();
        }

        public void DisplayIntro()
        {
            Console.WriteLine("Ready to play the Rock, Paper, Scissors, Lizard, Spock game?");
            Console.WriteLine("Best 2 out of 3 Wins");
        }

        public void DisplayRules()
        {
            Console.WriteLine("\nHere are the rules:");

            foreach (string rule in rules)
            {
                Console.WriteLine(rule);
            }
        }

        public void GetPlayer()
        {
            int userInput;
            
            Console.WriteLine("\nOne Player (vs AI) or Two Players (player vs player) mode? (1 or 2)");
            userInput = Int32.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                playerOne = new Human("player one");
                playerTwo = new AI("Jarvis");

                Console.Write("\nEnter Player One's name:");
                playerOneName = Console.ReadLine();
                playerOne.name = playerOneName;
                
                Console.WriteLine("Your Opponent is {0}", playerTwo.name);
            }
            else if (userInput == 2)
            {
                playerOne = new Human("player one");
                playerTwo = new Human("player two");

                Console.Write("\nEnter Player One's name: ");
                playerOneName = Console.ReadLine();

                Console.Write("Enter Player Two's name: ");
                playerTwoName = Console.ReadLine();

                playerOne.name = playerOneName;
                playerTwo.name = playerTwoName;
            }
            else
            {
                GetPlayer();
            }

            Console.WriteLine();
            Console.WriteLine(playerOne.name + " vs " + playerTwo.name);
        }

        public void StartPlay()
        {
            while ((playerOne.score < 2) && (playerTwo.score < 2))
            {
                playerOne.GetGesture();
                playerTwo.GetGesture();

                CalculateScore();

                playerOne.DisplayScore();
                playerTwo.DisplayScore();
            } 
        }

        public void CalculateScore()
        {
            int d = 5;
            d = (5 + playerOne.gesture - playerTwo.gesture) % 5;

            if ((d == 1) || (d == 3))
            {
                DisplayGestureOutcome();
                Console.WriteLine("{0} wins this round.\n", playerOne.name);
                playerOne.CheckScore();
            }
            else if ((d == 2) || (d == 4))
            {
                DisplayGestureOutcome();
                Console.WriteLine("{0} wins this round.\n", playerTwo.name);
                playerTwo.CheckScore();
            }
            else if (d == 0)
            {
                Console.WriteLine("\nIt's a Tie\n");
            }
        }

        public void DisplayGestureOutcome()
        {
            foreach (string rule in rules)
            {
                if (rule.IndexOf(playerOne.inputChoice, StringComparison.InvariantCultureIgnoreCase) > -1 && rule.IndexOf(playerTwo.inputChoice, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    Console.WriteLine();
                    Console.WriteLine(rule);
                }
            }
        }

        public void GetWinner()
        {
            if (playerOne.score == 2)
            {
                Console.WriteLine("\nGame Over.  {0} wins the game.", playerOne.name);
            }
            else
            {
                Console.WriteLine("\nGame Over.  {0} wins the game.", playerTwo.name);
            }
        }
        
        public void PlayAgain()
        {
            string userInput;

            Console.WriteLine("\nPlay Again? (Yes or No)");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "yes")
            {
                playerOne.score = 0;
                playerTwo.score = 0;
                PlayGame();
            }
            else
            {
                Console.WriteLine("Hone your skills");
            }
        }
    }
}
