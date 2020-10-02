using System;

namespace Orikivo
{
    /// <summary>
    /// Represents a monitored balance container.
    /// </summary>
    public class OffshoreWallet
    {
        /// <summary>
        /// The name of the offshore wallet.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The type of offshore wallet used.
        /// </summary>
        public WalletType Type { get; set; }

        /// <summary>
        /// The amount of money that is required to be in an offshore wallet to remain as usable.
        /// </summary>
        public static ulong MinimumBalance = 100;

        /// <summary>
        /// The amount of times a user can withdraw funds until it is placed on cooldown.
        /// </summary>
        public static int WithdrawLimit = 5;

        /// <summary>
        /// The amount of available money a user has to spend.
        /// </summary>
        public ulong Balance {get; set;}

        /// <summary>
        /// The multiplier rate of the funds per withdraw reset.
        /// </summary>
        public double InterestRate {get; set;}

        /// <summary>
        /// The amount of withdraws performed on this wallet.
        /// </summary>
        public int Withdraws { get; set; }

        /// <summary>
        /// The duration of a withdraw tracker until it resets.
        /// </summary>
        public TimeSpan? Cooldown { get; set; }

        /// <summary>
        /// The date of the last time a user has made a transaction.
        /// </summary>
        public DateTime? LastTransaction {get; set;}
    }
}