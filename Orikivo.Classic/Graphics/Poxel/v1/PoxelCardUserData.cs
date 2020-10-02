using Discord;
using Discord.WebSocket;

namespace Orikivo
{
    // the card of the user being rendered.
    public class PoxelCardUserData
    {
        public PoxelCardUserData(SocketUser user, Account account)
        {
            Name = account.Name;
            Activity = user.Activity;
            Experience = account.Experience;
            Balance = account.Balance;
            Debt = account.Debt;
        }

        public string Name { get; }
        public IActivity Activity { get; }
        public ulong Experience { get; }
        public ulong Balance { get; }
        public ulong Debt { get; }
    }
}
