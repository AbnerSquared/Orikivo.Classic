using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Defines the basic properties of an object that can be voted for.
    /// </summary>
    public interface IPostable
    {
        ulong Upvotes { get; set; }
        ulong Downvotes { get; set; }
        ulong Favorites { get; set; }
        ulong Views { get; set; }
        List<PostComment> Comments { get; set; }
    }
}