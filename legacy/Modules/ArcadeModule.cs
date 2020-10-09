using Discord;
using Discord.Commands;
using Orikivo.Systems.Presets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("Arcade")]
    [Summary("Enter the new dawn of useless entertainment.")]
    [DontAutoLoad]
    public class ArcadeModule : ModuleBase<OrikivoCommandContext>
    {
        public ArcadeModule()
        {

        }

        [Command("editsession")]
        public async Task EditSessionEmbed(string title, string description = null, string footer = null)
        {
            if (Context.Server.OpenGameSessions.Funct())
            {
                Context.Server.OpenGameSessions[0].Refresh(Context.Guild, title, description, footer);
                return;
            }

            await ReplyAsync("no sessions to edit.");
        }

        [Command("newsession")]
        [Summary("Start a new session test.")]
        public async Task SessionTest()
        {
            if (Context.Server.OpenGameSessions.Funct())
            {
                await ReplyAsync("A session is already open.");
                return;
            }
            GameSession.Build(Context.Guild, Context.Server, new WerewolfGame());
            await ReplyAsync("Session built.");
            Context.Data.Update(Context.Server);
        }



        [Command("endsession")]
        [Summary("Close all sessions")]
        public async Task SessionTest2()
        {
            if (Context.Server.OpenGameSessions.Funct())
            {
                Context.Server.CloseSessions(Context.Guild);
                await ReplyAsync("sessions closed.");
                return;
            }
            await ReplyAsync("no sessions found.");
        }

        [Command("games")]
        [Summary("View a list of available games.")]
        public async Task GamesResponseAsync()
        {
            WerewolfGame g = new WerewolfGame();
            EmbedBuilder e = new EmbedBuilder();
            e.WithColor(EmbedData.GetColor("error"));
            e.WithTitle("Ori's Arcade Zone");
            e.WithDescription($"{g.Status} **{g.Name}**\n{g.Summary}");//"The arcade is currently closed. Please hang tight while the arcade is being repaired. Sorry about that.");
            e.WithFooter("The arcade is currently closed. :(");
            await ReplyAsync(embed: e.Build());
        }

        public async Task GetTempEmbed(string name)
        {
            switch (name)
            {
                case "rolegen": await ReplyAsync(embed: WerewolfEmbedder.RoleGenerationTemplate()); return;
                case "roleassign": await ReplyAsync(embed: WerewolfEmbedder.RoleAssignTemplate()); return;
                case "night1": await ReplyAsync(embed: WerewolfEmbedder.FirstNightTemplate()); return;
                case "night": await ReplyAsync(embed: WerewolfEmbedder.NightTemplate()); return;
                case "death1": await ReplyAsync(embed: WerewolfEmbedder.FirstDeathTemplate()); return;
                case "death": await ReplyAsync(embed: WerewolfEmbedder.DeathTemplate()); return;
                case "convict": await ReplyAsync(embed: WerewolfEmbedder.SuspicionTemplate()); return;
                case "motion2": await ReplyAsync(embed: WerewolfEmbedder.SecondMotionTemplate()); return;
                case "defense": await ReplyAsync(embed: WerewolfEmbedder.DefenseTemplate()); return;
                case "vote": await ReplyAsync(embed: WerewolfEmbedder.VotingTemplate()); return;
                case "seerscan": await ReplyAsync(embed: WerewolfEmbedder.SeerScanTemplate()); return;
                case "seeroutcome": await ReplyAsync(embed: WerewolfEmbedder.SeerOutcomeTemplate()); return;
                case "wolfget": await ReplyAsync(embed: WerewolfEmbedder.WerewolfSelectionTemplate()); return;
                case "wolfbreak": await ReplyAsync(embed: WerewolfEmbedder.WerewolfBreakdownTemplate()); return;
                case "wolfoutcome": await ReplyAsync(embed: WerewolfEmbedder.WerewolfOutcomeTemplate()); return;
            }
        }

        [Command("templates"), Alias("tmp")]
        [Summary("Preview a collection of display presets for a game.")]
        public async Task GetTemplatesAsync(string template = null)
        {
            List<string> temps = new List<string>
            {
                "rolegen", "roleassign",
                "night1", "night",
                "death1", "death",
                "convict", "motion2",
                "defense", "vote",
                "seerscan", "seeroutcome",
                "wolfget","wolfbreak","wolfoutcome"
            };

            if (template.Exists())
            {
                if (template.EqualsAny(temps))
                {
                    await GetTempEmbed(template);
                    return;
                }
            }

            await ReplyAsync($"Werewolf Base Templates: {string.Join(" || ", temps)}");
            return;

        }
    }
}