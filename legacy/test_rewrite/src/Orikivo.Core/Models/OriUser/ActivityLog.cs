namespace Orikivo
{
    public class ActivityLog
    {
        // logging components
        public WordLog Words {get; set;} // a list of words the account has used.
        public ulong MessagesSent {get; set;}
        public ulong AttachmentsSent {get; set;}
        public CachedMessage LastMessage {get; set;} // date of message sent, location of message sent


        // subclass logging components
        public ArcadeLog Arcade {get; set;} // log of arcade history
        public CasinoLog Casino {get; set;} // log of casino events
        public UsageLog Usage {get; set;} // log of bot usage.
        public InventoryLog Inventory {get; set;} // log of item collections.
        public ActionLog Actions {get; set;} // log of all actions (trading, buying/selling, etc.)
    }
}