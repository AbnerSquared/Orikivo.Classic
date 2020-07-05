using Newtonsoft.Json;
using Orikivo.Services;

namespace Orikivo
{
    public class Account2GamblingBox
    {
        //[JsonProperty("bestwin")]
        //public WagerResult LowestWin { get; set; }

        //[JsonProperty("worstloss")]
        //public WagerResult HighestLoss { get; set; }

        [JsonProperty("mostwagered")]
        public Receipt MostWagered { get; set; }

        [JsonProperty("wagered")]
        public BankStatement Wagered { get; set; }

        [JsonProperty("topmode")]
        public WagerMode Favorite { get; set; }

        //[JsonProperty("bets")]
        //public List<WagerResult> BetHistory { get; set; }
    }
}
