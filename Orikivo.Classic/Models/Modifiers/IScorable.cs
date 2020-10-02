using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Defines the basic properties of an object that can be scored.
    /// </summary>
    public interface IScorable
    {
        List<ulong> Upvotes { get; set; }
        List<ulong> Downvotes { get; set; }
        void Upvote(ulong id);
        void Downvote(ulong id);
    }
}