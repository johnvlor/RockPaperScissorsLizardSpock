using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class AI : Player
    {
        public int aiChoice;

        public AI(string name)
        {
            this.name = name;
            this.aiChoice = 0;
        }

        public override void GetGesture()
        {
            Console.Write("\n{0} throws... ", name);
            DetermineGesture();
            AssignGesture();
        }

        public void DetermineGesture()
        {
            Random r = new Random();
            aiChoice = r.Next(5);

            if (aiChoice == 0)
            {
                inputChoice = "rock";
                Console.WriteLine(inputChoice);               
            }
            else if (aiChoice == 1)
            {
                inputChoice = "paper";
                Console.WriteLine(inputChoice);
            }
            else if (aiChoice == 2)
            {
                inputChoice = "scissors";
                Console.WriteLine(inputChoice);
            }
            else if (aiChoice == 4)
            {
                inputChoice = "lizard";
                Console.WriteLine(inputChoice);
            }
            else if (aiChoice == 3)
            {
                inputChoice = "spock";
                Console.WriteLine(inputChoice);
            }
        }

    }
}
