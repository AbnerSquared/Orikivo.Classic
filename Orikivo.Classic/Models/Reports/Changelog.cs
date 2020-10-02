using System;
using Discord;
using Newtonsoft.Json;

namespace Orikivo
{
    public class Changelog
    {
        [JsonConstructor]
        public Changelog(string name, string content, UpdateType type, ulong id, OriVersion version, DateTime date)
        {
            Name = name;
            Content = content;
            Type = type;
            Id = id;
            Version = version;
            Date = date;
        }

        public Changelog(OldGlobal g, string updateName, string content, UpdateType type, ulong id)
        {
            g.Version.Update(type);
            Name = updateName;
            Content = content;
            Type = type;
            Id = id;
            Version = g.Version;
            Date = DateTime.Now;
        }

        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("version")]
        public OriVersion Version { get; set; }

        [JsonProperty("type")]
        public UpdateType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public EmbedBuilder Generate()
        {
            EmbedBuilder e = new EmbedBuilder();
            EmbedFooterBuilder f = new EmbedFooterBuilder();

            string title = $"Orikivo\n    ↳ {Name}";
            string footer = $"Version {Version.ToString()} | ID: {Id}";

            f.WithText(footer);
            e.WithTitle(title);
            e.WithDescription(Content);
            e.WithFooter(f);
            return e;
        }
    }
}