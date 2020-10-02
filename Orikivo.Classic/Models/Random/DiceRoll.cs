using Orikivo.Providers;

namespace Orikivo
{
    public class DiceRoll
    {
        public DiceRoll(Dice dice)
        {
            Dice = dice;
            Result = RandomProvider.Instance.Roll(Dice);
            Max = (ulong)Dice.Sides;
        }

        public Dice Dice { get; } // dice used to roll
        public int Result { get; } // total roll score
        public ulong Max { get; } // max roll possible

        public override string ToString()
        {
            return $"{Dice.ToString()} | {Result}/{Max}";
        }

    }
}