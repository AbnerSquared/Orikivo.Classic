using System.Threading.Tasks;
using Discord.Commands;

namespace Orikivo.Modules
{
    [Name("Plaza")]
    [Summary("The world that thrives within Orikivo.")]
    [DontAutoLoad]
    public class PlazaModule : ModuleBase<OrikivoCommandContext>
    {
        //[Command("stores"), Alias("shops", "shl")]
        [Summary("Get the status of each current shop.")]
        public async Task StoreCollectionResponseAsync()
            => await ModuleManager.TryExecute(Context.Channel, PlazaService.CheckStoresAsync(Context));
    }
}
