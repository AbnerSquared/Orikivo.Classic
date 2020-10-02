using Newtonsoft.Json;
using System;

namespace Orikivo
{
    // the reward of a challenge or merit.
    public class Reward
    {
        public Reward(RewardType type, ulong amount, OriItem item = null)
        {
            Type = type;

            switch(type)
            {
                case RewardType.Item:
                    if (item == null)
                        throw new Exception("RewardType.Item requires that an item be specified to reward.");
                    else
                        Item = item;
                    break;
            }

            Amount = amount;
        }

        [JsonProperty("reward_type")]
        public RewardType Type { get; }
        [JsonProperty("item")] // as item_id
        public OriItem Item { get; } // the item to be rewarded.
        [JsonProperty("amount")]
        public ulong Amount { get; } // however much should be rewarded, if the item is null, it will automate to money.
    }
}
