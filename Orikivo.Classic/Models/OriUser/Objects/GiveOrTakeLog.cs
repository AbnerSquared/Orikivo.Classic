namespace Orikivo
{
    public class GiveOrTakeLog
    {
        public ulong TimesPlayed {get; set;}

        public ulong Wins {get; set;} // a general count on wins
        public ulong Losses {get; set;} // a general count on losses.

        public ulong Midas {get; set;} // rare win
        public ulong Curses {get; set;} // rare loss
        public ulong Earns {get; set;} // normal win
        public ulong Steals {get; set;} // normal loss

        public ulong HighestMidasChain {get; set;} // the highest midas chain earned
        public ulong HighestCurseChain {get; set;} // the highest curse chain earned
        public ulong HighestEarnChain {get; set;} // highest earn chain
        public ulong HighestStealChain {get; set;} // highest steal chain

        public ulong HighestWinChain {get; set;} // generic winning chain
        public ulong HighestLossChain {get; set;} // generic losses chain

        public ulong LargestValueChainPool {get; set;}
        public ulong LargestDebtChainPool {get; set;}

        public ulong TotalValuePool {get; set;}
        public ulong TotalDebtPool {get; set;}

        public ulong MidasChain {get; set;}
        public ulong CurseChain {get; set;}
        public ulong EarnChain {get; set;}
        public ulong StealChain {get; set;}
        
        public ulong WinChain {get; set;}
        public ulong LossChain {get; set;}

        public ulong ValueChainPool {get; set;}
        public ulong DebtChainPool {get; set;}
    }
}