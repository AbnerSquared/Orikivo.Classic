using Newtonsoft.Json;
using System.Collections.Generic;

namespace Orikivo
{
    public class OriColorPacket
    {
        [JsonProperty("id")]
        uint Id { get; set; }

        [JsonProperty("socket_id")]
        uint? SocketId { get; set; } // if an OriItem has this ID, the color will be mapped to that OriItem.

        [JsonProperty("map")]
        Dictionary<int, OriColor> Map { get; }
    }
}
