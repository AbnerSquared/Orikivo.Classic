namespace Orikivo
{
    public class GiveOrTakeAnalyzer
    {
        public int GoldenCount { get; set; }
        public int PlayCount { get; set; }
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public int WinStreak { get; set; }
        public int LossStreak { get; set; }
        public long WinStreakAmount { get; set; }
        public long LossStreakAmount { get; set; }
        public int MaxWinStreak { get; set; }
        public int MaxLossStreak { get; set; }
        public long MaxWinStreakAmount { get; set; }
        public long MaxLossStreakAmount { get; set; }

        public int MaxLossAmountStreak { get; set; }
        public long MaxLossAmount { get; set; }
        public int MaxWinAmountStreak { get; set; }
        public long MaxWinAmount { get; set; }
        public long WinAmount { get; set; }
        public long LossAmount { get; set; }
        public long TotalOutcome { get { return WinAmount - LossAmount; } }

        public void Track(bool b, bool g, long u)
        {
            PlayCount += 1;
            if (b)
            {
                if (g)
                {
                    GoldenCount += 1;
                }
                else
                {
                    WinCount += 1;
                }
                WinAmount += u;
            }
            else
            {
                LossCount += 1;
                LossAmount += u;
            }

            if (!b)
            {
                WinStreak = 0;
                LossStreak += 1;
                WinStreakAmount = 0;
                LossStreakAmount += u;
            }
            else
            {
                WinStreak += 1;
                LossStreak = 0;
                LossStreakAmount = 0;
                WinStreakAmount += u;
            }

            if (WinStreak > MaxWinStreak)
            {
                MaxWinStreakAmount = WinStreakAmount;
                MaxWinStreak = WinStreak;
            }
            if (LossStreak > MaxLossStreak)
            {
                MaxLossStreakAmount = LossStreakAmount;
                MaxLossStreak = LossStreak;
            }
            if (WinStreakAmount > MaxWinAmount)
            {
                MaxWinAmount = WinStreakAmount;
                MaxWinAmountStreak = WinStreak;
            }
            if (LossStreakAmount > MaxLossAmount)
            {
                MaxLossAmount = LossStreakAmount;
                MaxLossAmountStreak = LossStreak;
            }
        }
    }
}
