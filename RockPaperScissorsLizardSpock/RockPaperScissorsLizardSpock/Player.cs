using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Player
    {
        public string name;
        public int gesture;
        public int score;
        public string inputChoice;
        List<string> playerGestures;

        public Player()
        {
            playerGestures = new List<string>()
            {
                "rock", "paper", "scissors", "spock", "lizard"
            };
        }

        public virtual void GetGesture()
        {
            Console.Write("\n{0} throws... ", name);
            inputChoice = Console.ReadLine().ToLower();

            if ((inputChoice == "rock") || (inputChoice == "paper") || (inputChoice == "scissors") || (inputChoice == "spock") || (inputChoice == "lizard"))
            {
                AssignGesture();
            }
            else
            {
                Console.WriteLine("Not an option.  Must be 'rock', 'paper', 'scissors', 'lizard', or 'spock'.  \nTry again");
                GetGesture();
            }
        }

        public void AssignGesture()
        {
            gesture = playerGestures.IndexOf(inputChoice);
        }

        public int CheckScore()
        {
            return score += 1;
        }

        public void DisplayScore()
        {
            Console.WriteLine("{0}'s Score: {1}", name, score);
        }
    }
}
