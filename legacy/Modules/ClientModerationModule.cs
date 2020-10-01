using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("ClientModeration")]
    [Summary("Configurable client-side mechanics for Orikivo.")]
    [DontAutoLoad]
    public class ClientModerationModule : ModuleBase<OrikivoCommandContext>
    {
        [Command("mute")]
        public async Task MuteAsync() { }

        [Command("setmmrole")]
        public async Task SetMusicManagerRoleAsync() { }

        [Command("promotemm")]
        public async Task AddMusicManagerAsync() { }

        [Command("toggleentrymessages")]
        public async Task ToggleEntryMessagesAsync() { }

        [Command("togglegreetings")]
        public async Task ToggleGreetingsAsync() { }

        public async Task ToggleLeavingsAsync() { }

        public async Task DefaultEntryMessagesAsync() { }

        [Command("addgreeting")]
        public async Task AddGreetingAsync() { }

        [Command("removegreeting")]
        public async Task RemoveGreetingAsync() { }

        [Command("cleargreetings")]
        public async Task ClearGreetingsAsync() { }



        [Command("addleaving")]
        public async Task AddLeavingAsync() { }

        [Command("removeleaving")]
        public async Task RemoveLeavingAsync() { }

        [Command("clearleavings")]
        public async Task ClearLeavingsAsync() { }
    }
}