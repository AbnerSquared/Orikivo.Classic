using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Orikivo
{
    public class Account2InteractionBox
    {
        [JsonProperty("spokenwords")]
        public List<SpokenContext> Spoken { get; set; }

        [JsonProperty("sentfiles")]
        public ulong FileCount { get; set; }

        [JsonProperty("sentmessages")]
        public ulong MessageCount { get; set; }

        [JsonProperty("mentions")]
        public ulong Mentions { get; set; }

        [JsonProperty("mdlang")]
        public MarkdownLanguage FavoriteMarkdown { get; set; }

        //[JsonProperty("recent")]
        //public CompactMessage Recent { get; set; }

        [JsonProperty("lasttyped")]
        public DateTime LastTyped { get; set; }

        [JsonProperty("lastsent")]
        public DateTime LastSent { get; set; }

        [JsonProperty("swears")]
        public ulong Swears { get; set; }
    }
}
