using System;
using Orikivo.Providers;
using Orikivo.Static;

namespace Orikivo.Services
{
    public static class CasinoService
    {
        public static CasinoResult BetCoinFlip(OldAccount a, ulong wager, bool face = true)
        {
            WagerMode mode = WagerMode.CoinFlip;
            double reward = wager * 2;
            bool victory = false;

            bool flip = RandomProvider.Instance.Flip();
            if (flip == face)
            {
                victory = true;
            }

            decimal risk = RiskManager.MeasureCoinRisk();

            string input = face.AsCoinFlip();
            string outcome = flip.AsCoinFlip();

            return new CasinoResult(a, mode, wager, victory, risk, reward, input, outcome);
        }

        public static CasinoResult DoubleOrNothing(OldAccount a, ulong wager, int times)
        {
            WagerMode mode = WagerMode.Doubler;
            double reward = wager * Math.Pow(2, times);
            int wins = 0;
            bool victory = false;

            bool alive = true;

            while (alive)
            {
                if (RandomProvider.Instance.Next(0, 100) >= 45)
                {
                    wins += 1;
                    continue;
                }

                alive = false;
            }

            if (wins >= times)
            {
                victory = true;
            }

            string input = $"{times.ToPlaceValue()} Tick{(times > 1 ? "s":"")}";
            string outcome = $" Died at Tick {wins.ToPlaceValue()}";

            decimal risk = RiskManager.MeasureDoublerRisk(times);
            //decimal risk = (decimal)(reward / wager);
            CasinoResult result = new CasinoResult(a, mode, wager, victory, risk, reward, input, outcome);

            if (times > 1)
            {
                string summbase = "You needed {0} to earn {1}!";
                int left = (int)times - wins;
                string req = $"{(left > 1 ? $"to win {left} more times" : $"{"one".MarkdownBold()} more win")}";
                string money = $"{EmojiIndex.Balance}" + "{0}".MarkdownBold();
                result.WithLosingSummary(string.Format(summbase, req, string.Format(money, reward.ToPlaceValue())));
            }

            return result;
        }

        //exceptions should be caught before the bet.
        public static CasinoResult BetRangedRoll(OldAccount a, Dice d, int wager, int mp, bool dir = false)
        {
            WagerMode mode = WagerMode.RangedRoll;
            int lower = dir ? 1 : 2;
            int upper = dir ? (d.Sides - 1) : d.Sides;

            DiceRoll r = d.Roll();

            bool victory = false;
            if (dir)
            {
                if (r.Result > mp)
                {
                    victory = true;
                }
            }
            else
            {
                if (r.Result < mp)
                {
                    victory = true;
                }
            }

            decimal risk = RiskManager.MeasureRangedRisk(d, mp, dir);
            double reward = (double)Math.Round(wager * risk);
            // D6, Above 4
            string input = $"{d.ToString()}, {(dir ? "Above" : "Under")} {mp}";
            string outcome = $"{r.Result}";

            return new CasinoResult(a, mode, wager, victory, risk, reward, input, outcome);
        }

        public static CasinoResult BetSelectiveRoll(OldAccount a, Dice d, int wager, params int[] sides)
        {
            WagerMode mode = WagerMode.SelectiveRoll;
            DiceRoll r = d.Roll();

            bool victory = false;

            if (r.Result.EqualsAny(sides))
                victory = true;

            decimal risk = RiskManager.MeasureSelectiveRisk(d, sides);
            double reward = (double)Math.Round(risk * wager);

            string input = $"{d.ToString()}, [{string.Join(", ", sides)}]";
            string outcome = $"{r.Result}";

            return new CasinoResult(a, mode, wager, victory, risk, reward, input, outcome);
        }
    }
}