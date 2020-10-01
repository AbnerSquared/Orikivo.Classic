using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("UserOptions")]
    [Summary("Detailed controls for specific options.")]
    [DontAutoLoad]
    public class UserOptionsModule : ModuleBase<OrikivoCommandContext>
    {
        public UserOptionsModule() { }


        [Command("autofix")]
        public async Task AutoFixResponseAsync()
        {

        }

        [Command("autofixtoggle")]
        public async Task AutoFixToggleAsync()
        {

        }

        [Command("overflow")]
        public async Task OverflowResponseAsync()
        {

        }

        [Command("overflowtoggle")]
        public async Task OverflowToggleAsync()
        {

        }

        [Command("tooltips")]
        public async Task TooltipsResponseAsync()
        {

        }

        [Command("tooltipstoggle")]
        public async Task TooltipsToggleAsync()
        {

        }

        //nickname
        [Command("clearnickname")]
        public async Task ClearNicknameAsync()
        {

        }

        [Command("nickname"), Priority(0)]
        public async Task NicknameResponseAsync()
        {

        }

        [Command("nickname"), Priority(1)]
        public async Task NicknameResponseAsync(string name)
        {

        }

        [Command("clearprefix")]
        public async Task ClearPrefixAsync()
        {

        }

        [Command("prefix")]
        public async Task PrefixResponseAsync()
        {
            // make it to where if the user doesn't have a personal one set, it derives from the server-side, or the global default.
        }

        [Command("prefix")]
        public async Task SetPrefixAsync(string value)
        {

        }

        //end prefix
        [Command("clearendprefix")]
        public async Task ClearEndPrefixAsync()
        {

        }

        [Command("endprefix")]
        public async Task EndPrefixResponseAsync()
        {

        }

        [Command("endprefix")]
        public async Task SetEndPrefixAsync(string value)
        {

        }

        [Command("clearlocaleblacklist")]
        public async Task ClearLocaleBlacklistAsync()
        {

        }

        [Command("localeblacklist"), Alias("bannedwords")]
        public async Task LocaleBlacklistResponseAsync()
        {
            // see all banned words.
        }

        [Command("blockword")]
        public async Task BlockWordAsync(string word)
        {
            // add to the chat blacklist.
        }

        [Command("revokeword")]
        public async Task RevokeWord(string word)
        {

        }

        [Command("clearsiteblacklist")]
        public async Task ClearSiteBlacklistAsync()
        {

        }

        [Command("siteblacklist")]
        public async Task SiteBlacklistResponseAsync()
        {

        }

        [Command("blocksite")]
        public async Task BlockSiteAsync(string url)
        {

        }

        [Command("revokesite")]
        public async Task RevokeSiteAsync(string url)
        {

        }

        // this will remove all sites that start with this.
        [Command("revokebasesite")]
        public async Task RevokeMatchingBaseSitesAsync(string url)
        {

        }

        [Command("linking")]
        public async Task LinkingResponseAsync()
        {

        }

        [Command("linkingtoggle")]
        public async Task LinkingToggleAsync()
        {

        }

        [Command("exceptions"), Alias("throw")]
        public async Task ThrowResponseAsync()
        {

        }

        [Command("exceptionstoggle"), Alias("throwtoggle")]
        public async Task ThrowToggleAsync()
        {

        }

        [Command("safeguard")]
        public async Task SafeGuardResponseAsync()
        {

        }

        [Command("safeguardtoggle")]
        public async Task SafeGuardToggleAsync()
        {

        }

        [Command("outputformat")]
        public async Task OutputFormatResponseAsync()
        {

        }

        [Command("outputformat"), Priority(1)]
        public async Task SetOutputFormatAsync(OutputFormat format) // make an OutputFormat TypeReader
        {

        }

        [Command("nullformat")]
        public async Task NullFormatResponseAsync()
        {

        }

        [Command("nullformat"), Priority(1)]
        public async Task SetNullFormatAsync(NullObjectHandling value) // make a NullObjectHandling TypeReader.
        {

        }

        [Command("visibility")]
        public async Task VisibilityResponseAsync()
        {

        }

        [Command("visibility"), Priority(1)]
        public async Task SetVisibilityAsync(Visibility value) // make a Visibility TypeReader.
        {

        }

        [Command("clearsledge"), Alias("clearinsultpower")]
        public async Task ClearSledgeAsync()
        {

        }

        [Command("sledge"), Alias("insultpower")]
        public async Task SledgeResponseAsync()
        {

        }

        [Command("sledge"), Alias("insultpower"), Priority(1)]
        public async Task SetSledgeAsync(SledgePower power) // make a SledgePower TypeReader.
        {

        }

        [Command("iconformat")]
        public async Task IconFormatResponseAsync()
        {

        }

        [Command("iconformat"), Priority(1)]
        public async Task SetIconFormatAsync()
        {

        }

        [Command("portablemode")]
        public async Task TogglePortableModeAsync()
        {

        }

        [Command("clearlocale")]
        public async Task ClearLocaleAsync()
        {

        }

        [Command("locale")]
        public async Task LocaleResponseAsync()
        {

        }

        [Command("locale"), Priority(1)]
        public async Task SetLocaleAsync(Locale language) // locale typereader
        {

        }

        [Command("predecode")]
        public async Task PreDecodeResponseAsync()
        {

        }

        [Command("predecodetoggle")]
        public async Task PreDecodeToggleAsync()
        {

        }

        [Command("globaldecode")]
        public async Task GlobalDecodeResponseAsync()
        {

        }

        [Command("globaldecodetoggle")]
        public async Task GlobalDecodeToggleAsync()
        {

        }

        [Command("directional")]
        public async Task DirectionalResponseAsync()
        {

        }

        [Command("directionaltoggle")]
        public async Task DirectionalToggleAsync()
        {

        }

        [Command("usernameformat")]
        public async Task NameFormatResponseAsync()
        {

        }

        [Command("usernameformat"), Priority(1)]
        public async Task SetNameFormatAsync(NameFormat format) // namedisplayformat typereader...?
        {

        }

        [Command("matchhandling")]
        public async Task MatchHandlingResponseAsync()
        {

        }

        [Command("matchhandling"), Priority(1)]
        public async Task SetMatchHandlingAsync()
        {

        }

        [Command("searchhandling")]
        public async Task SearchHandlingResponseAsync()
        {

        }

        [Command("searchhandling"), Priority(1)]
        public async Task SetSearchHandlingAsync()
        {

        }

        [Command("wordguardtoggle")]
        public async Task WordGuardToggleAsync()
        {

        }
        [Command("wordguard")]
        public async Task WordGuardResponseAsync()
        {

        }

        [Command("wordguard"), Priority(1)]
        public async Task SetWordGuardAsync()
        {

        }

        [Command("colorformat")]
        public async Task ColorFormatResponseAsync()
        {

        }

        [Command("colorformat"), Priority(1)]
        public async Task SetColorFormatAsync()
        {

        }

        [Command("iconnameformat")]
        public async Task IconNameFormatResponseAsync()
        {

        }

        [Command("iconnameformattoggle")]
        public async Task IconNameFormatToggleAsync()
        {

        }
    }
}