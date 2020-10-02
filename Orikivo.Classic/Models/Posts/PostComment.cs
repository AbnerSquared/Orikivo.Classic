using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Represents a comment on a post.
    /// </summary>
    public class PostComment : IScorable
    {
        public Author Author { get; set; } // the author of the comment.
        public string Content { get; set; } // the comment written.
        //public List<PostComment> Replies { get; set; } // the replies appended to the parent comment.
        public List<ulong> Upvotes { get; set; } // a list of all user ids that upvoted the comment.
        public List<ulong> Downvotes { get; set; } // a list of all user ids that downvoted the comment.
        // you cannot both upvote and downvote a post.

        public void Upvote(ulong id)
        {
            if (Upvotes.Contains(id))
                return;
            if (Downvotes.Contains(id))
                Downvotes.Remove(id);
            Upvotes.Add(id);
        }

        public void Downvote(ulong id)
        {
            if (Downvotes.Contains(id))
                return;
            if (Upvotes.Contains(id))
                Upvotes.Remove(id);
            Downvotes.Add(id);
        }
    }
}