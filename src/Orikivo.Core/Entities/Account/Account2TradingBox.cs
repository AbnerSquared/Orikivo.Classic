using Newtonsoft.Json;

namespace Orikivo
{
    public class Account2TradingBox
    {
        [JsonProperty("tradecount")]
        public ulong TradesMade { get; set; }

        //[JsonProperty("tradehistory")]
        //public List<TradeHistory> History { get; set; }
    }
}
