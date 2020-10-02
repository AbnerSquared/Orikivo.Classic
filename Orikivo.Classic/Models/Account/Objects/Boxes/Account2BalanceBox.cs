using Newtonsoft.Json;

namespace Orikivo
{
    public class Account2BalanceBox
    {
        //[JsonProperty("transactions")]
        //public List<Transaction2> Transactions { get; set; }

        [JsonProperty("totallost")]
        public BankStatement Expended { get; set; }

        [JsonProperty("totalwon")]
        public BankStatement Earned { get; set; }

        [JsonProperty("largestbalance")]
        public BankStatement MostHeld { get; set; }

        [JsonProperty("largestdebt")]
        public BankStatement MostOwed { get; set; }

        [JsonProperty("mostlost")]
        public Receipt MostSpent { get; set; }

        [JsonProperty("mostwon")]
        public Receipt MostEarned { get; set; }
        
    }
}
