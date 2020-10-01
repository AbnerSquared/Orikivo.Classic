using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("DiscordModeration")]
    [Summary("Configurable client-side mechanics for servers.")]
    [DontAutoLoad]
    public class DiscordModerationModule : ModuleBase<OrikivoCommandContext>
    {
        public DiscordModerationModule() { }

        [Command("ban")]
        public async Task BanAsync() { }

        [Command("softban")]
        public async Task SoftBanAsync() { }

        [Command("hackban")]
        public async Task HackBanAsync() { }

        [Command("editguild")]
        public async Task EditGuildAsync() { }

        // give user role
        // give user nickname
        // take user role
        // reset nickname
        // whitelist user on a channel
        // etc...?

        // literally clear everything pertaining to them.
        [Command("kick")]
        public async Task KickUserAsync() { }

        [Command("createrole")]
        public async Task CreateRoleAsync() { }

        [Command("editrole")]
        public async Task EditRoleAsync() { }

        [Command("deleterole")]
        public async Task DeleteRoleAsync() { }

        [Command("createchannel")]
        public async Task CreateChannelAsync() { }

        [Command("editchannel")]
        public async Task EditChannelAsync() { }

        [Command("deletechannel")]
        public async Task DeleteChannelAsync() { }

        [Command("purge")]
        public async Task PurgeAsync() { }

        [Command("clonechannel")]
        public async Task CloneChannelAsync() { }

        [Command("clonerole")]
        public async Task CloneRoleAsync() { }

        [Command("createcategory")]
        public async Task CreateCategoryAsync() { }

        [Command("editcategory")]
        public async Task EditCategoryAsync() { }

        [Command("deletecategory")]
        public async Task DeleteCategoryAsync() { }

        [Command("clonecategory")]
        public async Task CloneCategoryAsync() { }

        // this user will no longer be able to use orikivo server-wide.
        [Command("block")]
        public async Task BlockUserAsync() { }

        // bans a user, and will automatically ban them in the case of which you're both the owner AND Orikivo is in the server.
        [Command("globalban")]
        public async Task GlobalBlockUserAsync() { }

        [Command("addemoji")]
        public async Task AddEmojiAsync() { }

        [Command("editemoji")]
        public async Task EditEmojiAsync() { }

        [Command("deleteemoji")]
        public async Task DeleteEmojiAsync() { }

        [Command("pin")]
        public async Task PinMessageAsync() { }

        [Command("unpin")]
        public async Task UnpinMessageAsync() { }

        // clones the current channel, and deletes the original one.
        [Command("clearchannel")]
        public async Task ClearChannelAsync() { }


        // spamguard
        // spamguard warnings
        // spamguard duration

        // mute
        // unmute

        // warn
        // unwarn
    }
}