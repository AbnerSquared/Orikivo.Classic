using Discord;

namespace Orikivo
{
    public class ActivityInfo
    {   
        public ActivityInfo()
        {
            Name = "an empty name";
            Type = ActivityType.Watching;
        }

        public ActivityInfo(string name = null, ActivityType type = ActivityType.Watching)
        {
            Name = name ?? "an empty name";
            Type = type;
        }

        public ActivityType Type { get; set; }

        public string Name { get; set; }

        public override string ToString()
            => $"{Type.ToTypeString()} {Name}";
    }
}