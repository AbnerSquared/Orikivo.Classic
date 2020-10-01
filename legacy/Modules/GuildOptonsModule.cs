
using Discord.Commands;

namespace Orikivo.Modules
{
    [Name("GuildOptions")]
    [Summary("Detailed controls for guild-specific options.")]
    [DontAutoLoad]
    public class GuildOptionsModule : ModuleBase<OrikivoCommandContext>
    {
        public GuildOptionsModule() { }

    }
}