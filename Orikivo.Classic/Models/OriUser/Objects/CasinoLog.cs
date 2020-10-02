using System.Collections.Generic;

namespace Orikivo
{
    public class CasinoLog
    {
        // append a limiter.
        public List<CasinoGameResult> History {get; set;} // a list of all recent games
        public GiveOrTakeLog GiveOrTake {get; set;}
    }
}