using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("Analysis")]
    [Summary("Provides statistics on a range of objects.")]
    public class AnalyticsModule
    {
        public AnalyticsModule()
        {

        }

        //[Command("analyze")]
        public async Task AnalyzeObjectResponseAsync()
        {

        }



        /*
                [Command("npxlacc")]
                [Summary("A rewritten pixel profile tool.")]
                public async Task BuildCardAsync()
                {
                    string card = PixelEngine.GetCardAsPath(Context.User, new PixelRenderingOptions(Context.Account));
                    EmbedBuilder e = new EmbedBuilder();
                    e.WithImageUrl($"attachment://{Path.GetFileName(card)}");
                    await Context.Channel.SendFileAsync(card, embed: e.Build());
                }
        */
    }
}