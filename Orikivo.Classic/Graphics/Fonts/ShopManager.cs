using Orikivo.Storage;

namespace Orikivo
{
    public static class ShopManager
    {
        static ShopManager()
        {
            Shops = FileManager.GetShops();
        }

        public static ShopCache Shops { get; }
    }
}