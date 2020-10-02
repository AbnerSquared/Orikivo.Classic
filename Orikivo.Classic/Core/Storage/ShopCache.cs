using System.Collections.Generic;

namespace Orikivo.Storage
{
    public class ShopCache
    {
        public ShopCache(List<OriShop> shops)
        {
            Shops = shops;
        }

        public List<OriShop> Shops { get; set; }
    }
}