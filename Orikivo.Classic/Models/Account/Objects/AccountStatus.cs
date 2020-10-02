using Discord;

namespace Orikivo
{
    /// <summary>
    /// Represents a custom user display status through Orikivo.
    /// </summary>
    public class AccountStatus
    {
        public UserStatus Status { get; set; }
        public string Note { get; set; }
    }
}
