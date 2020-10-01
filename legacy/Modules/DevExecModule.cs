using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("DevExec")]
    [Summary("Configuration mechanics only available to the bot developer(s).")]
    [DontAutoLoad]
    public class DevExecModule : ModuleBase<OrikivoCommandContext>
    {
        public DevExecModule() { }

        // completely block a user from using orikivo
        [Command("__prohibit")]
        public async Task DevBlockUserAsync() { }

        [Command("__revoke")]
        public async Task DevUnblockUserAsync() { }

        [Command("__unload")]
        public async Task UnloadModuleAsync() { }

        [Command("__disable")]
        public async Task DisableModuleAsync() { }

        // only the program reboots themselves
        // save a (if reboot) toggle, and have it to where it notifiies the last channel it was executed in to the user.
        [Command("__reboot")]
        public async Task RebootAsync() { }

        // restart the entire computer, and return to it having the host.
        [Command("__reboothost")]
        public async Task HostRebootAsync() { }

        // get a user's .json data.
        [Command("__getuser")]
        public async Task GetUserAsync() { }

        // if they were exploiting/ doing not good, they'll get reset.
        [Command("__resetuser")]
        public async Task ResetUserAsync() { }

        [Command("__taskmanager")]
        public async Task TaskManagerAsync() { }

        [Command("__shell")]
        public async Task CommandLineAsync() { }
    }
}