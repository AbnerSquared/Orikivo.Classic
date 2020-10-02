using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace Orikivo
{
    /// <summary>
    /// Represents a SocketUser on Orikivo.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Constructs a new Account based off of a SocketUser.
        /// </summary>
        public Account(SocketUser u)
        {
            Id = u.Id;
            Username = u.Username;
            Discriminator = u.DiscriminatorValue;
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Constructs a new Account with its creation date set to when it was constructed.
        /// </summary>
        public Account()
        {
            CreationDate = DateTime.Now;
        }



        //Components
        ///<summary>
        /// A check to see if the profile card is up to date on information.
        ///</summary>
        [JsonIgnore]
        public bool Updated { get; set; }

        ///<summary>
        /// A check to see if the profile card is currently refreshing.
        ///</summary>
        [JsonIgnore]
        public bool IsBuilding { get; set; }

        ///<summary>
        /// A value used to identify an account. Inherits from Discord.WebSocket.SocketUser.
        ///</summary>
        [JsonProperty("id")]
        public ulong Id { get; set; }

        ///<summary>
        /// The written username of an account. Inherits from Discord.WebSocket.SocketUser.
        ///</summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        ///<summary>
        /// A sub-value used to identify an account, in the occurance of having the exact same name.
        ///</summary>
        [JsonProperty("discriminator")]
        public ushort Discriminator { get; set; }

        ///<summary>
        /// The System.DateTime component of when this account was created.
        ///</summary>
        [JsonProperty("createdat")]
        public DateTime CreationDate { get; set; }

        ///<summary>
        /// An optional component displaying basic information.
        ///</summary>
        [JsonProperty("status")]
        public PersonalityChart Personality { get; set; }

        ///<summary>
        /// The available amount of money that can be spent.
        ///</summary>
        [JsonProperty("balance")]
        public ulong Balance { get; set; } = 0;

        ///<summary>
        /// A bank account keeping track of wallets.
        ///</summary>
        [JsonProperty("offshore")]
        public OffshoreBalance Offshore { get; set; }

        ///<summary>
        /// A pool of fines that prevent income until it is empty.
        ///</summary>
        [JsonProperty("debt")]
        public ulong Debt { get; set; } = 0;

        ///<summary>
        /// The reset counter of an account.
        ///</summary>
        [JsonProperty("prestige")]
        public ulong Prestige { get; set; }

        ///<summary>
        /// Experience group derived from experience.
        ///</summary>
        [JsonProperty("level")]
        public ulong Level { get; set; }

        ///<summary>
        /// The raw percentile level value.
        ///</summary>
        [JsonProperty("rawlevel")]
        public double RawLevel { get; set; }

        ///<summary>
        /// The current value of experience earned.
        ///</summary>
        [JsonProperty("xp")]
        public ulong Experience { get; set; }

        ///<summary>
        /// Keeps track of all earned rewards.
        ///</summary>
        [JsonProperty("merits")]
        public MeritCollection Merits { get; set; }

        ///<summary>
        /// Keeps track of upgrades.
        ///</summary>
        //[JsonProperty("upgrades")]
        //public ComponentCollection Upgrades { get; set; }

        ///<summary>
        /// Manages all cooldowns.
        ///</summary>
        //[JsonProperty("cooldowns")]
        //public CooldownManager Cooldowns { get; set; }

        ///<summary>
        /// The basis of how an account functions.
        ///</summary>
        [JsonProperty("options")]
        public AccountOptions Options { get; set; }

        ///<summary>
        /// Controls when an account is notified.
        ///</summary>
        [JsonProperty("notifiers")]
        public Notificator Notifiers { get; set; }

        ///<summary>
        /// Contains the current personal status of a user.
        ///</summary>
        [JsonProperty("status")]
        public AccountStatus Status { get; set; }

        ///<summary>
        /// Keeps track of items.
        ///</summary>
        [JsonProperty("inventory")]
        public Account2Inventory Inventory { get; set; }

        ///<summary>
        /// Holds all saved playlists.
        ///</summary>
        //[JsonProperty("playlists")]
        //public List<Playlist2> Playlists { get; set; }

        ///<summary>
        /// Contains a collection of saved events.
        ///</summary>
        [JsonProperty("events")]
        public Calendar Events { get; set; }

        /// <summary>
        /// Contains a collection of favorite Clipboards.
        /// </summary>
        [JsonProperty("starred")]
        public ClipboardCollection Starred { get; set; }

        ///<summary>
        /// A mailbox that follows all inbound letters.
        ///</summary>
        [JsonProperty("mail")]
        public Mailbox Mail { get; set; }

        ///<summary>
        /// A core component that keeps a tab on every action performed.
        ///</summary>
        [JsonProperty("stats")]
        public Analyzer Analytics { get; set; }

        /// <summary>
        /// Defines how much money the user can hold.
        /// </summary>
        [JsonProperty("walletsize")]
        public ulong WalletCapacity { get; set; }
        //#endregion

        // Static methods used for certain scenarios.
        #region ReadOnly

        /// <summary>
        /// The remaining wallet space a user can store.
        /// </summary>
        [JsonIgnore]
        public ulong WalletSpace { get { return WalletCapacity - Balance; } }

        /// <summary>
        /// Checks if the user currently has expendable funds.
        /// </summary>
        [JsonIgnore]
        public bool HasMoney { get { return !(Balance == 0); } }

        /// <summary>
        /// Checks if the user currently has fines in the debt pool.
        /// </summary>
        [JsonIgnore]
        public bool InDebt { get { return !(Debt == 0); } }

        /// <summary>
        /// Returns the name of this account.
        /// </summary>
        [JsonIgnore]
        public string Name { get { return Options.Nickname ?? Username ?? $"U{Id}"; } }

        /// <summary>
        /// Returns the base name of this account.
        /// </summary>
        [JsonIgnore]
        public string DefaultName { get { return $"{Username}#{Discriminator}"; } }

        /// <summary>
        /// Returns the Discord.WebSocket.SocketUser counterpart.
        /// </summary>
        [JsonIgnore]
        public SocketUser User { get { return Global.Client.GetUser(Id); } }
        #endregion

        // Methods that return a summary of a component.
        #region ReadMethods
        #endregion

        /// <summary>
        /// Checks if the user can afford to spend a specified value.
        /// </summary>
        public bool CanExpend(double v)
            => !(Balance - v < 0);

        /// <summary>
        /// Checks if the user has room to store a specified value.
        /// </summary>
        public bool CanStore(double v)
            => !(Balance + v > WalletCapacity);

        // long is allowed to go negative.
        public long TrueBalance { get { return (long)Balance - (long)Debt; } }

        // Actions that alter the components of an account.
        #region Methods
        /// <summary>
        /// Replaces the current balance of the user to a specified value.
        /// </summary>
        public void SetBalance(ulong balance)
        {
            balance = balance > WalletCapacity ? WalletCapacity : balance;
            Balance = balance;
            //Analytics.TryUpdateMaxHeld(Balance);
        }

        /// <summary>
        /// Completely wipes all money for the user.
        /// </summary>
        public void ClearBalance()
        {
            Balance = 0;
        }

        /// <summary>
        /// Gives the user a specified value.
        /// </summary>
        public void Give(ulong v)
        {
            Balance += CanStore(v) ? v : WalletSpace;
            //Analytics.TryUpdateMaxHeld(Balance);
        }

        /// <summary>
        /// Takes money or what's left of it, if it goes over.
        /// </summary>
        public void TakeRemainder(ulong v)
        {
            Balance -= CanExpend(v) ? v : Balance;
            //Analytics.UpdateExpended(v);
        }

        /// <summary>
        /// Takes money from the user.
        /// </summary>
        private void Take(ulong v)
        {
            Balance -= v;
            //Analytics.UpdateExpended(v);
        }

        /// <summary>
        /// Attempts to buy an item.
        /// </summary>
        public bool TryBuy(Item i)
            => TryTake(i.Cost);

        /// <summary>
        /// Attempts to take money from the user.
        /// </summary>
        public bool TryTake(ulong v)
        {
            if (!HasMoney)
                return false;

            if (!CanExpend(v))
                return false;

            Take(v);
            return true;
        }

        /// <summary>
        /// Attempts to take money from the user or what's left of it, if it goes over.
        /// </summary>
        public bool TryTakeRemainder(ulong v)
        {
            if (!CanExpend(v))
            {
                if (Options.Overflow)
                    v = Balance;
                else
                    return false;
            }

            TakeRemainder(v);
            return true;
        }

        /// <summary>
        /// Sends money to another user.
        /// </summary>
        public void Pay(OldAccount a, ulong v)
        {
            if (!HasMoney)
                return;

            if (!CanExpend(v))
            {
                if (Options.Overflow)
                    v = Balance;
                else
                    return;
            }
            Take(v);
        }

        /// <summary>
        /// Take money from another user.
        /// </summary>
        public void Steal(OldAccount a, ulong v)
        {

        }

        /// <summary>
        /// Adds money to the debt pool.
        /// </summary>
        public void Fine(ulong v)
        {
            Debt += v;
            //Analytics.UpdateExpended(v);
        }

        /// <summary>
        /// Automatically subtracts given money from the debt pool.
        /// </summary>
        private void PayDebt()
        {
            if (!InDebt)
                return;

            if (!CanExpend(Debt))
            {
                ulong v = (ulong)(Debt - Math.Abs(Balance - (double)Debt));
                Take(v);
                Debt -= v;
                return;
            }

            Take(Debt);
            ClearDebt();
        }

        /// <summary>
        /// Completely wipes all debt.
        /// </summary>
        public void ClearDebt()
            => Debt = 0;
        
        #endregion

        // Methods that overwrite a base function.
        #region Overloads
        public bool Equals(Account a)
            => Id == a.Id;

        public override string ToString()
            => $"a::{DefaultName}";
        #endregion
    }
}
