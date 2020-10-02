using Discord.WebSocket;
using System;
using System.Collections.Generic;

namespace Orikivo
{
    public class Clipboard2
    {
        public string Id { get; set; } // The id of the clipboard.
        public Author Author { get; set; }
        public ClipboardSource Source { get; set; } // the actual data that makes up the clipboard.
        //public List<ClipboardReport> Reports { get; set; } = new List<ClipboardReport>(); // reports that this clipboard has.
        public DateTime CreationDate { get; set; }
        public DateTime? LastEdited { get; set; }



        public bool SafeGuard { get; set; } // a toggle made by the poster themselves.
        public bool SafeModGuard { get; set; } // a toggle made by moderators. must be contacted to repair.

        private List<ulong> Upvotes { get; set; }
        private List<ulong> Downvotes { get; set; }
        public long VoteScore { get { return Upvotes.Count - Downvotes.Count; } }
        public ulong Views { get; set; } // amount of times it was called.

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

        public void Favorite(Account a)
        {
            // append this clipboard to their favorites by id. whenever they call it
        }
    }

    // save a post, and it renders into a cleaner display.
}
