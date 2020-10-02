using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Orikivo.Networking;
using Orikivo.Static;
using Orikivo.Storage;

namespace Orikivo
{
    // For orikivo's global config.

    public class OldGlobal
    {
        [JsonIgnore]
        public const string ClientName = "Orikivo";

        [JsonIgnore]
        public const string ClientVersion = "0.0.580-prerelease";

        [JsonIgnore]
        public const string VotingUrl = "https://discordbots.org/bot/433079994164576268/vote";

        public OldGlobal()
        {
            Activity = new ActivityInfo();
        }

        public OriVersion Version { get; set; } = new OriVersion();
        public string Avatar { get; set; } // Image Orikivo uses.
        public string Username { get; set; } // The username Orikivo holds.
        public ActivityInfo Activity { get; set; } = new ActivityInfo(); // The current activity that Orikivo is doing.
        public UserStatus Status { get; set; } // The current status of Orikivo.
        public Locale Locale { get; set; } // The language Orikivo uses.
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Report> AcceptedReports { get; set; } = new List<Report>();
        public List<Changelog> Changelogs = new List<Changelog>();
        public ulong IssueOutput { get; set; } // where issues are sent.
        public ulong CaseIncrement { get; set; } // the global report case id counter.
        // issues are only offloaded (sent twice into the same channel, if the original cannot be found.)

        public void AddChangelog(Changelog c)
        {
            if (Changelogs.Contains(c))
                return;

            Changelogs.Add(c);
        }


        // in the case of invalid reports
        public void EnsureCaseIncrement()
        {
            CaseIncrement = 1;
            foreach (Report r in Reports.OrderBy(x => x.Id))
            {
                r.Id = CaseIncrement;
                CaseIncrement += 1;
            }
        }

        public Changelog GetRecentChangelog()
            => Changelogs.OrderByDescending(x => x.Date).FirstOrDefault();
        
        public bool TryGetChangelog(ulong id, out Changelog changelog)
        {
            changelog = null;
            if (!Changelogs.Any(x=> x.Id == id))
            {
                return false;
            }

            changelog = Changelogs.Where(x => x.Id == id).FirstOrDefault();
            return true;
        }

        public void LogReport(Report report)
        {
            if (Reports.Any(x => x.Id == report.Id))
            {
                return;
            }

            Reports.Add(report);
            CaseIncrement += 1;
        }

        public void DeleteReport(Report report)
        {
            Reports.Remove(report);
        }

        public async Task NotifyCompleteReportAsync(OldAccount a, OrikivoCommandContext Context, Report report, Changelog changelog)
        {
            ulong reward = 100;
            string b = $"The report that was accepted ({report.Id}) has been built on {changelog.Name} ({changelog.Id}). Thank you for your input!\nYou have been awarded {EmojiIndex.Balance}{reward.ToPlaceValue().MarkdownBold()} for your time. Keep up the good work.";
            //CompactMessage msg = new CompactMessage(b);
            //OldMail m = new OldMail("Orikivo", $"({report.Id}) has been built!", msg);
            //await m.SendAsync(a, Context.Client);
        }

        public async Task NotifyAcceptedReportAsync(OldAccount a, OrikivoCommandContext Context, Report report)
        {
            //CompactMessage msg = new CompactMessage($"The report you submitted ({report.Id}) has been accepted!\nYou will be notified upon the completion of your input.\nThank you for your time!");
            //OldMail m = new OldMail("Orikivo", "Your report has been accepted!", msg);
            //await m.SendAsync(a, Context.Client);
        }

        public async Task NotifyDeclinedReportAsync(OldAccount a, OrikivoCommandContext Context, Report report, string reason)
        {
            //CompactMessage msg = new CompactMessage($"The report you submitted ({report.Id}) has been declined. Here's what the director of the motion stated:```{reason ?? "It failed to meet the criteria of an report."}```");
            //OldMail m = new OldMail("Orikivo", "Your report has been declined.", msg);
            //await m.SendAsync(a, Context.Client);
        }

        public async Task CompleteReport(OldAccount a, OrikivoCommandContext Context, ulong id, ulong changelogId)
        {
            if (!TryGetChangelog(changelogId, out Changelog changelog))
            {
                await Context.Channel.SendMessageAsync("You need to specify a changelog ID to complete a report.");
                return;
            }

            if (TryGetAcceptedReport(id, out Report report))
            {
                AcceptedReports.Remove(report);
                await NotifyCompleteReportAsync(a, Context, report, changelog);
                return;
            }

            await Context.Channel.SendMessageAsync("The id used does not exist in the list of reports.");
        }

        public async Task AcceptReport(OldAccount a, OrikivoCommandContext Context, ulong id)
        {
            if (TryGetReport(id, out Report report))
            {
                DeleteReport(report);
                AcceptedReports.Add(report);
                await NotifyAcceptedReportAsync(a, Context, report);
                return;
            }

            await Context.Channel.SendMessageAsync("The id used does not exist in the list of reports.");
        }

        public async Task DeclineReport(OldAccount a, OrikivoCommandContext Context, ulong id, string reason = null)
        {
            if (TryGetReport(id, out Report r))
            {
                DeleteReport(r);
                await NotifyDeclinedReportAsync(a, Context, r, reason);
                return;
            }

            await Context.Channel.SendMessageAsync("The id used does not exist in the list of reports.");
        }

        public bool TryGetAcceptedReport(ulong id, out Report report)
        {
            report = null;
            if (!AcceptedReports.Any(x => x.Id == id))
            {
                return false;
            }

            report = AcceptedReports.FirstOrDefault(x => x.Id == id);
            return true;
        }

        public bool TryGetReport(ulong id, out Report report)
        {
            report = null;
            if (!Reports.Any(x => x.Id == id))
            {
                return false;
            }

            report = Reports.FirstOrDefault(x => x.Id == id);
            return true;
        }

        public void Save()
            => Manager.Save(this, FileManager.TryGetPath(this));

        public void SetActivity(ActivityInfo a)
        {
            Activity = a ?? new ActivityInfo();
        }
        public void SetActivity(string name = null, ActivityType type = ActivityType.Watching)
            => SetActivity(new ActivityInfo(name, type));

        // Logging data
        // Module data 
    }

    public class RvGlobal
    {
        private static OriWebClient _client;
        public static readonly string ClientName = "Orikivo";
        public static readonly string ClientVersion = "0.60.0-rv";
        public static readonly ulong[] DeveloperIds = new ulong[] { };
        public static readonly ulong CreatorId = 181605794159001601;
        public static readonly Range PrefixLimit = new Range(1, 16);
        public static readonly Range NicknameLimit = new Range(2, 32);
        public static readonly string VotingUrl = "https://discordbots.org/bot/433079994164576268/vote";
        public static readonly List<string> BlacklistedWords = new List<string> { "heck" };

        public static DiscordSocketClient Client { get; internal set; }

        public static OriWebClient WebClient => _client ??= OriWebClient.Default;

        public static bool IsDeveloper(ulong userId)
            => userId == CreatorId || DeveloperIds != null && DeveloperIds.Any(id => id == userId);

        [JsonIgnore]
        public Version Version { get; set; }

        [JsonIgnore]
        public Uptime Uptime { get; set; }

        [JsonIgnore]
        public DateTime StartedAt { get; set; }

        [JsonProperty("reports")]
        public ReportCollection Reports { get; set; }

        [JsonProperty("report_counter")]
        public ulong ReportCounter { get; set; }

        [JsonProperty("clipboards")]
        public ClipboardCollection Clipboards { get; set; }

        [JsonProperty("report_channel_id")]
        public ulong ReportChannelId { get; set; }

        [JsonProperty("icons")]
        public IconManager Icons { get; set; }

        public bool TryGetClipboard(ulong id, out List<Clipboard2> clipboards)
        {
            clipboards = null;

            if (Clipboards.ContainsAuthor(id))
            {
                clipboards = Clipboards.FromAuthor(id);
                return true;
            }

            return false;
        }
    }
}