using System.Collections.Generic;

namespace Orikivo
{
    public class Account2Inventory
    {
        public ulong Capacity { get; set; }
        public List<TradeOffer> Trades { get; set; }
        public List<Item> Personals { get; set; }
        public List<Item> Consumables { get; set; }
        // public List<Item> Consumables { get { return Items.Where(x => x.IsSingleUse).ToList();}}

    }
}
