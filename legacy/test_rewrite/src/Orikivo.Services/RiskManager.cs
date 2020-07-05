using System;

namespace Orikivo.Services
{
    // handles all risk generation
    public static class RiskManager
    {
        public static decimal MeasureSelectiveRisk(Dice d, params int[] sides)
            => MeasureRisk(d, sides.Length);

        public static decimal MeasureRisk(Dice d, int winnable)
            => 1 / ((decimal)winnable / (decimal)d.Sides);

        public static decimal MeasureRangedRisk(Dice d, int mp, bool dir)
        {
            int w = dir ? d.Sides - mp : mp - 1;
            return MeasureRisk(d, w);
        }

        public static decimal MeasureCoinRisk()
            => 1 / (decimal)(1d / 2d);

        public static decimal MeasureDoublerRisk (int times)
        {
            /*
            const int range = 45;
            const int limit = 100;

            decimal previous = 1;

            for (int i = 0; i < times; i++)
            {
                previous = (range * previous) / limit;
                previous.Debug();
            }

            return previous;*/

            return (decimal)(Math.Pow(2, times));
        }
    }
}