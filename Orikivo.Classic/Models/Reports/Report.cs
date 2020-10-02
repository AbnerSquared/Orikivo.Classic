using System;
using System.Collections.Generic;
using System.Linq;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Newtonsoft.Json;
using Orikivo.Systems.Presets;
using Orikivo.Utility;

namespace Orikivo
{
    public class Report
    {
        [JsonConstructor]
        public Report(OriReportPriorityType type, Author author, string subject, string command, string content, ulong id)
        {
            Id = id;
            Author = author;
            Type = type;
            Command = command;
            Subject = subject;
            Content = content;

        }

        public Report(OrikivoCommandContext ctx, RestUserMessage message)
        {
            List<Embed> embeds = message.Embeds.ToList();

            if (embeds.Count > 0)
            {
                EmbedBuilder e = embeds.FirstOrDefault().ToEmbedBuilder();

                string sbj = "Subject: ";
                string bid = "BugID: ";

                string[] title = e.Title.Split('\n');

                string.Join("\n", title).Debug();


                string[] top = title[0].Split(" | ");
                string.Join(" | ", top).Debug();


                string emoji = top[0];

                string fullname = top[1];
                fullname.Debug("fullname length");

                string username = fullname.Substring(0, fullname.Length - 5);

                Debugger.Write("i passed this 5");
                // force ignore hashtag.
                string discriminator = top[1].Substring(username.Length + 1);

                Debugger.Write("i passed this 6");
                string sid = e.Footer.Text.Substring(bid.Length);

                Debugger.Write("i passed this 7");
                string command = top[2];
                Debugger.Write("i passed this 8");

                Emoji flag = new Emoji(emoji.Unescape());
                SocketUser u = ctx.Client.GetUser(username, discriminator);

                if (!u.Exists())
                {
                    ctx.Channel.SendMessageAsync($"user not found ({username}, {discriminator})");
                    throw new Exception("Invalid User: No User Fits the Statement.");
                }

                string subject = title[1].Substring(sbj.Length).TryUnwrap("**");
                string content = e.Description;
                ulong id = ulong.Parse(sid);

                Id = id;
                Author = new Author(u);
                Type = flag.GetFlagType();
                Command = command;
                Subject = subject;
                Content = content;
                return;
            }

            throw new Exception("Invalid Message: No Embeds in Container.");
        }

        public Report(OldAccount a, OriReportPriorityType type, ulong id, CommandInfo command, string content, string subject = null)
        {
            Type = type;
            Subject = subject ?? type.GetName();
            Author = new Author(a);
            Command = $"{command.Module.Name ?? command.Module.ToString()}.{command.Name}".ToLower();
            Content = content;
            Id = id;
        }

        public Report(OldAccount a, OriReportPriorityType type, ulong id, string command, string content, string subject = null)
        {
            Type = type;
            Subject = subject ?? type.GetName();
            Author = new Author(a);
            Command = command;
            Content = content;
            Id = id;
        }

        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("type")]
        public OriReportPriorityType Type { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
        

        public EmbedBuilder Generate(OldAccount a)
        {
            EmbedBuilder e = new EmbedBuilder();
            Emoji icon = Type.Icon();
            string user = $"{Author.Name}";
            string subject = $"Subject: {Subject.MarkdownBold()}";
            string title = $"{icon.Pack(a)} | {user} | {Command}\n{subject}";
            string footer = $"Case: {Id}";

            EmbedFooterBuilder f = new EmbedFooterBuilder();
            f.WithText(footer);

            e.WithColor(EmbedData.GetColor("error"));
            e.WithTitle(title);
            e.WithDescription(Content);
            e.WithFooter(f);

            return e;
        }

        public string ToString(OldAccount a)
            => $"[{$"{Id}".MarkdownBold()}] {Type.Icon().Pack(a)} {Author.Name}";
    }
}