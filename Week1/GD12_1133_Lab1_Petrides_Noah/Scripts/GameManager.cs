using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Petrides_Noah.Scripts
{
    /// <summary>
    /// Main game logic
    /// </summary>
    internal class GameManager
    {
        /// <summary>
        /// Game entry point
        /// </summary>
        internal void PlayGame()
        {
            Console.WriteLine("Welcome to Die vs Die!");

            // Setting up the DieRoller
            DieRoller sixSidedDie = new DieRoller();
            // two player instances
            Player user = new Player();
            Player cpu = new Player();

            Player currentTurn = user;

            Console.WriteLine("Which die would you like to roll?");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                DieRoller userSizeDie = new DieRoller();
                userSizeDie.numberOfSides = number;
                userSizeDie.RollAndScore(ref user.score);
            }
            else
            {
                Console.WriteLine("Error! Please enter a number!");
            }

            // this adds the result to the score (the game manager does it)
            if (sixSidedDie.Roll(out int randomlyRolledValue))
            {
                currentTurn.score += randomlyRolledValue;
            }
            // this adds the score to the player (the die roller does it)
            sixSidedDie.RollAndScore(ref currentTurn.score);

            // Display result
            Console.WriteLine($"{user.score} vs {cpu.score}");
        }
    }
}
