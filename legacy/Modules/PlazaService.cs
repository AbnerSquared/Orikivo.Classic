using System.Threading.Tasks;
using Orikivo.Utility;

namespace Orikivo.Modules
{
    public static class PlazaService
    {
        // user can dropoff items
        // user can pickup items

        // check user inventory..?
        public static async Task CheckStorageAsync()
        {

        }

        public static async Task CheckStoresAsync(OrikivoCommandContext Context)
        {
            MessageBuilder mb = ShopSystem.CheckStores();
            await Context.Channel.SendSourceAsync(mb.Build());
        }
    }
}