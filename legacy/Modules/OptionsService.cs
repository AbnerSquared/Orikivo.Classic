using Discord;
using Orikivo.Utility;
using System.Threading.Tasks;

namespace Orikivo.Modules
{
    /// <summary>
    /// Represents all of the working methods for OptionsModule.
    /// </summary>
    public static class OptionsService
    {
        public static async Task ReadOptionAsync(OrikivoCommandContext Context, string s)
        {
            if (!OptionsHelper.TryParseOption(s, out AccountOption ao))
            {
                await Context.Channel.ThrowAsync("Invalid context.", "The context specified led to no results.");
                return;
            }
            await Context.Channel.ReadAsync(ao.Interpret(), Context.Account);
        }

        public static async Task ReadOptionAsync(OrikivoCommandContext Context, AccountOption option)
        {
            await Context.Channel.ReadAsync(option.Interpret(), Context.Account);
        }

        public static async Task ReadOptionAsync(OrikivoCommandContext Context, int i)
        {
            if (!OptionsHelper.TryParseOption(i, out AccountOption ao))
            {
                await Context.Channel.ThrowAsync("Invalid context.", "The integer specified led to no results.");
                return;
            }
            await Context.Channel.ReadAsync(ao.Interpret(), Context.Account);
        }

        public static async Task ReadOptionAsync(OrikivoCommandContext Context, Emoji e)
        {
            if (!OptionsHelper.TryParseOption(e, out AccountOption ao))
            {
                await ReadOptionAsync(Context, e.Name);
                //await Context.Channel.ThrowAsync("Invalid context.", "The icon specified led to no results.");
                return;
            }
            await Context.Channel.ReadAsync(ao.Interpret(), Context.Account);
        }

        public static async Task ReadOptionsAsync(OrikivoCommandContext Context)
        {
            await Context.Channel.SendEmbedAsync(OptionsHelper.InterpretAll().PeekAll(Context.Account));
        }

        public static async Task SetOptionAsync(OrikivoCommandContext Context, AccountOption option, object obj)
        {
            AccountOptions opts = AccountOptions.Default;
            opts.TryGetValue(option, out object value);
            if (opts.TrySetValue(option, obj))
            {
                string msg = $"{option} - {(value.Exists() ? value.Read() : "Undefined")}";
                opts.TryGetValue(option, out value);
                msg += $" => {(value.Exists() ? value.Read() : "Undefined")}";
                await Context.Channel.SendMessageAsync(msg);
            }
        }
    }
}
