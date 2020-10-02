using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Orikivo
{
    /// <summary>
    /// Represents an object used to randomly select numbers.
    /// </summary>
    public class Dice
    {
        [JsonIgnore]
        private const int DefaultSides = 6;

        [JsonIgnore]
        public const int MaximumSides = 100;

        [JsonIgnore]
        public const int MinimumSides = 1;

        [JsonIgnore]
        public static Dice Default = new Dice();

        public Dice (int sides)
        {
            sides = Ensure(sides);
            Sides = sides;
        }

        public Dice()
        {
            Sides = DefaultSides;
        }

        public int Sides { get; set; }
        //public int Amount { get; set; }

        public static bool TryParse(string s, out List<Dice> d)
        {
            d = new List<Dice>();
            Regex pattern = new Regex(@"\d*d\d{1,3}");
            List<Match> matches = pattern.Matches(s).ToList();
            if (matches.Count == 0)
                return false;

            foreach (Match m in matches)
            {
                m.Value.Debug();
                string[] info = m.Value.Split('d');
                string.Join('\n', info).Debug();
                if (info.Length == 2)
                {
                    int amount = int.Parse(info[0]);
                    int sides = int.Parse(info[1]);
                    d.Add(new Dice(sides));
                }
                if (info.Length == 1)
                {
                    int sides = int.Parse(info[0]);
                    d.Add(new Dice(sides));
                }
            }

            return true;
        }

        private int Ensure(int sides)
        {
            return sides.InRange(MinimumSides, MaximumSides);
        }

        public DiceRoll Roll()
        {
            return new DiceRoll(this);
        }

        public DiceRollBatch RollMany(int amount)
        {
            return new DiceRollBatch(this, amount);
        }
        public override string ToString()
        {
            return $"D{Sides}";
        }
    }
}