using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    [Name("Options")]
    [Summary("Provides helpers for configurable settings.")]
    [DontAutoLoad]
    public class OptionsModule : ModuleBase<OrikivoCommandContext>
    {
        public OptionsModule() { }

        // get info on all possible values of an option.
        [Command("optionvalues")]
        public async Task OptionValueTypesResponseAsync()
        {

        }

        [Command("option")]
        [Summary("Learn about a specified option in depth.")]
        public async Task OptionResponseAsync
        (
            [Name("context"), Summary("The option to view context for.")] AccountOption option
        )
        {
            await ModuleManager.TryExecute(Context.Channel, OptionsService.ReadOptionAsync(Context, option));
        }

        // sort of like an advanced version of editing commands.
        [Command("setoption")]
        [Summary("Edit the value of a specified account option. This is dynamic, and will work off of what you provide.")]
        public async Task SetOptionAsync
        (
            [Name("context"), Summary("The option to view context for.")] AccountOption option,
            [Name("value"), Summary("The new value to be set in place of the option.")] object value = null
        )
        {
            await ModuleManager.TryExecute(Context.Channel, OptionsService.SetOptionAsync(Context, option, value));
        }

        [Command("alloptions")]
        [Summary("See all current options that derive from your account.")]
        public async Task OptionsResponseAsync()
        {
            await ModuleManager.TryExecute(Context.Channel, OptionsService.ReadOptionsAsync(Context));
        }
    }
}
