using Discord.Commands;
using System.Threading.Tasks;
using Discord.WebSocket;
using Orikivo.Systems.Services;

namespace Orikivo.Modules
{
    [Group("status"), Name("Status"), Alias("st")]
    [Summary("Prevent mentions from bugging you when you need it.")]
    public class Status : ModuleBase<OrikivoCommandContext>
    {
        private readonly StatusService _status;

        public Status(StatusService status)
        {
            _status = status;
        }

        [Command("")]
        [Summary("Displays your current status, or of the user called.")]
        public async Task StatusAsync([Remainder] SocketUser target = null)
        {
            SocketUser sender = target;
            if (target == null)
            {
                sender = Context.Message.Author;
            }

            await _status.StatusRead(sender, Context);
        }

        [Command("clear")]
        [Summary("Clear your current status.")]
        public async Task StatusSet()
        {
            await _status.ClearStatus(Context);
        }

        [Command("set")]
        [Summary("Set your status with an optional message.")]
        public async Task StatusSet(string statusType, [Remainder] string message = "")
        {
            await _status.SetStatus(Context, statusType, message);
        }
    }
}