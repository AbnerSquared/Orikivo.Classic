using System;

namespace Orikivo
{
    public class ClaimMerit
    {
        public ClaimMerit(Merit merit)
        {
            Source = merit;
            Claimed = merit.Rewards == null ? true : false;
            EarnedAt = DateTime.UtcNow;
        }
        public Merit Source { get; }
        public bool Claimed { get; private set; }
        public DateTime EarnedAt { get; }

        /*
        public void Claim(OriUser user)
        {
            if (Claimed)
                return;

            if (Source.Rewards == null)
                return;
            foreach (Reward reward in Source.Rewards)
            {
                switch (reward.Type)
                {
                    case RewardType.Item:
                        if (reward.Item == null)
                            throw new Exception("The Reward.Item required to award is missing.");
                        user.Inventory.Store(reward.Item, reward.Amount);
                        break;
                    case RewardType.Money:
                        user.Wallet.Give(reward.Amount);
                        break;
                }
            }

            Claimed = true;
        }
        */
    }
}
