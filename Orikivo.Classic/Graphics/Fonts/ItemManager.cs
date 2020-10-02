using Orikivo.Storage;
using System.Linq;

namespace Orikivo
{
    public static class ItemManager
    {
        public static ItemCache ItemMap { get; private set; }

        static ItemManager()
        {
            ItemMap = FileManager.GetItems();
        }

        public static bool HasGroup(ushort id)
            => ItemMap.Items.Any(x => (ushort)x.Group == id);
    }
}