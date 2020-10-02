using System.Collections.Generic;
using Newtonsoft.Json;
using Orikivo.Providers;

namespace Orikivo
{
    public class DiceRollBatch
    {
        [JsonIgnore]
        private const int DefaultAmount = 1;

        [JsonIgnore]
        public const int MaximumAmount = 100;

        [JsonIgnore]
        public const int MinimumAmount = 1;

        public DiceRollBatch(Dice dice, int amount)
        {
            Dice = dice;
            amount = Ensure(amount);
            Amount = amount;
            Rolls = RandomProvider.Instance.RollMany(Dice, amount);
            Result = Rolls.Tally();
            Max = (ulong)(Amount * Dice.Sides);
        }

        /// <summary>
        /// The dice that used in the batch roll.
        /// </summary>
        public Dice Dice { get; }

        /// <summary>
        /// The amount of dice that was rolled.
        /// </summary>
        public int Amount { get; } // amount of dice rolled.

        /// <summary>
        /// A collection of all rolls.
        /// </summary>
        public List<int> Rolls { get; } // a list of all rolls

        /// <summary>
        /// The total count of all dice rolls.
        /// </summary>
        public ulong Result { get; } // total roll score

        /// <summary>
        /// The total count of all dice sides.
        /// </summary>
        public ulong Max { get; } // max roll possible

        
        /// <summary>
        /// Makes sure the dice roll limit is in range.
        /// </summary>
        private int Ensure(int amount)
        {
            return amount.InRange(MinimumAmount, MaximumAmount);
        }

        public override string ToString()
        {
            return $"{(Amount > 1 ? $"{Amount}" : "")}{Dice.ToString()} | {Result}/{Max}";
        }

    }
}