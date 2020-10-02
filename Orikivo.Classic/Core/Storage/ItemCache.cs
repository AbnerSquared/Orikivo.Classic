using System.Collections.Generic;

namespace Orikivo.Storage
{
    public class ItemCache
    {
        public ItemCache(List<OriItem> items)
        {
            Items = items;
        }

        public List<OriItem> Items { get; set; }
    }
}