using System.Collections.Generic;

namespace Orikivo
{
    public class OriUserInventory
    {
        public List<OriItem> Items { get; }
        public void Store(OriItem item, ulong amount = 1)
        {
            for (ulong i = 0; i < amount; i++)
                Items.Add(item);
        }
    }
}