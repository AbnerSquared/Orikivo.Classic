using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Orikivo
{
    public class OriUser
    {
        public OriUser()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public OriUser(SocketUser user) : this() // new account from default build.
        {
            Id = user.Id;
            Username = user.Username;
            Discriminator = user.Discriminator;
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; }

        [JsonProperty("id")]
        public ulong Id { get; }

        [JsonProperty("name")]
        public string Username { get; private set; }

        [JsonProperty("tag_id")]
        public string Discriminator { get; private set; }
    }
}
