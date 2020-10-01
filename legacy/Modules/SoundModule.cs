using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Orikivo.Systems.Dependencies;

namespace Orikivo.Modules
{
    [Name("Sound")]
    [Summary("Provides basic access to auditorial interaction.")]
    [DontAutoLoad]
    public class SoundModule : ModuleBase<ICommandContext>
    {
        private readonly CommandService _service;
        private readonly AudioDependency _audio;
        private readonly DiscordSocketClient _socket;
        private readonly IConfigurationRoot _config;
        private readonly CancellationTokenSource _token;

        public SoundModule(CommandService service,
            DiscordSocketClient socket,
            AudioDependency audio,
            IConfigurationRoot config,
            CancellationTokenSource token)
        {
            _service = service;
            _socket = socket;
            _audio = audio;
            _config = config;
            _token = token;
        }

        [Command("kalimba", RunMode = RunMode.Async)]
        [Summary("Play the best song in existance.")]
        public async Task KalimbaAsync()
        {
            var displayEmbed = new EmbedBuilder();
            displayEmbed.WithColor(255, 238, 129);
            displayEmbed.WithTitle("Requested Kalimba.");
            displayEmbed.WithDescription("You are ready to be enrichened to the best song built by mankind...");

            var channel = (Context.User as IGuildUser).VoiceChannel;
            if (channel == null)
            {
                await ReplyAsync("`You gotta join a channel for an ultimate experience like this. :^)`");
                return;
            }
            await _audio.JoinVoiceChannel(Context.Guild, channel);
            var baseMessage = await ReplyAsync(null, false, displayEmbed.Build());

            EmbedBuilder modifiedEmbed = new EmbedBuilder();
            foreach (var embed in baseMessage.Embeds)
            {
                modifiedEmbed = embed.ToEmbedBuilder();
                break;
            }
            if (_audio.IsPlaying(Context.Guild))
            {
                modifiedEmbed.WithColor(129, 243, 193);
                modifiedEmbed.WithTitle("Transcendence failed.");
                modifiedEmbed.WithDescription("Kalimba is too powerful to queue alongside multiple entities.");
            }
            await _audio.BuildStream(Context.Guild, Context.Channel, baseMessage, ".//data//songs//kalimba.mp3");

            modifiedEmbed.WithColor(129, 243, 193);
            modifiedEmbed.WithTitle("Transcendence complete.");
            modifiedEmbed.WithDescription("Kalimba is the best song built by mankind, and nobody can tell me otherwise.");
            await baseMessage.ModifyAsync(x => { x.Embed = modifiedEmbed.Build(); });
            await _audio.LeaveVoiceChannel(Context.Guild);
        }
    }
}