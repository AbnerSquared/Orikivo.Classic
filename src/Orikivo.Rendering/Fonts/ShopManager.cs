using Orikivo.Storage;

namespace Orikivo
{
    public static class ShopManager
    {
        public static ShopCache ShopMap { get; private set; }

        static ShopManager()
        {
            ShopMap = FileManager.GetShops();
        }
    }
}