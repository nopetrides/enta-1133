using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_Petrides_Noah.Scripts
{
    /// <summary>
    /// Randomly roll a specific die
    /// </summary>
    internal class DieRoller
    {
        /// <summary>
        /// The max roll
        /// </summary>
        internal int numberOfSides = 6;

        /// <summary>
        /// Randomly seeded random number generator
        /// </summary>
        Random randomNumberGenerator = new Random();

        /// <summary>
        /// Rolls the die and validates the number
        /// </summary>
        /// <returns>Random number between 1 and number of sides</returns>
        internal bool Roll(out int roll)
        {
            // random between min (inclusive) and max (exclusive)
            roll = randomNumberGenerator.Next(1,numberOfSides+1);
            // returns the number
            return roll >= 1 && roll <= numberOfSides;
        }

        /// <summary>
        /// Rolls and immediately add its to a referenced score
        /// </summary>
        /// <param name="score"></param>
        internal void RollAndScore(ref int score)
        {
            if (Roll(out int randomRollResult))
            {
                score += randomRollResult;
            }
        }
    }
}
