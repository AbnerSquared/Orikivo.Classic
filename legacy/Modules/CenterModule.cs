using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("Pad")]
    [Summary("Your own place of hope.")]
    [DontAutoLoad]
    public class CenterModule : ModuleBase<OrikivoCommandContext>
    {
        [Command("storage"), Alias("inventory", "inv", "stg")]
        [Summary("Look at all of the currently owned items you have.")]
        public async Task CheckStorageAsync()
        {

        }
    }
}