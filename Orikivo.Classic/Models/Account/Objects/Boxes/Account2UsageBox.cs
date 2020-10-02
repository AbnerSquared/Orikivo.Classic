using Newtonsoft.Json;

namespace Orikivo
{
    public class Account2UsageBox
    {
        [JsonProperty("usedcommands")]
        public ulong Executed { get; set; }

        [JsonProperty("errors")]
        public ulong Exceptions { get; set; }

        //[JsonProperty("commands")]
        //public List<CommandData> Commands { get; set; }
    }
}
