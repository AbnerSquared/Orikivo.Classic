using Discord.Commands;
using Newtonsoft.Json;

namespace Orikivo.Helpers
{
    public class CompactCommandInfo
    {
        public CompactCommandInfo(CommandInfo command)
        {
            RootModuleName = command.GetRootModule();
            ModuleName = command.Module.Name;
            if (command.Module.Group.Exists())
                GroupName = command.Module.Group;
            CommandName = command.Name;
            OverloadIndex = command.Priority;
        }

        [JsonProperty("root")]
        public string RootModuleName { get; } // name of the root module.
        [JsonProperty("module")]
        public string ModuleName { get; } // name of the module.
        [JsonProperty("group")]
        public string GroupName { get; } // the group name, if any.
        [JsonProperty("command")]
        public string CommandName { get; } // the main command name.

        [JsonProperty("overload_pos")]
        public int OverloadIndex { get; } // the priority number.
    }
}
