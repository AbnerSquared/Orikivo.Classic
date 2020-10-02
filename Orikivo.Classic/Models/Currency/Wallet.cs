using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Represents a balance container.
    /// </summary>
    public class Wallet
    {
        public Wallet()
        {
            Balance = 0;
            Debt = 0;
            _capacity = DefaultUserCapacity; // the base wallet capacity for all users.
        }

        public static ulong DefaultUserCapacity = 10000; // the basic wallet upper bound.

        private ulong? _capacity; // the capacity value to be stored, can be null.

        /// <summary>
        /// The most amount of money a user can hold before the wallet is full.
        /// </summary>
        public ulong Capacity { get { return _capacity ?? ulong.MaxValue; } }

        /// <summary>
        /// The amount of available money a user has to spend.
        /// </summary>
        public ulong Balance { get; set; }

        //private List<ulong> BalancePool { get; set; } // when money is over the ulong limit, create a new pool of money.

        ///<summary>
        /// A pool of fines that prevent income until it is cleared.
        ///</summary>
        public ulong Debt { get; set; }

        /// <summary>
        /// The remaining amount of funds that can be stored in this wallet.
        /// </summary>
        public ulong Remainder { get { return Capacity - Balance; } }

        /// <summary>
        /// Checks if the wallet has expendable funds.
        /// </summary>
        public bool HasBalance { get { return !(Balance == 0); } }

        /// <summary>
        /// Checks if the wallet has fines.
        /// </summary>
        public bool HasDebt { get { return !(Debt == 0); } }

        #region Methods

        public bool CanSpend(double v)
            => !(Balance - v < 0);

        public bool CanStore(double v)
            => !(Balance + v > Capacity);

        public void SetBalance(ulong balance)
            => Balance = balance > Capacity ? Capacity : balance;

        //give
        public void Give(ulong v)
            => Balance += CanStore(v) ? v : Remainder;

        //take
        public void TakeAll()
            => Balance = 0;

        public void Take(ulong v)
            => Balance -= v;

        public void TakeRemainder(ulong v)
            => Balance -= CanSpend(v) ? v : Balance;

        public bool TryTake(ulong v)
        {
            if (!HasBalance)
                return false;

            if (!CanSpend(v))
                return false;

            Take(v);
            return true;
        }

        // try take remainder goes to main account
        // pay goes to main acc
        // steal goes to main acc
        // 

        //debt
        public void Fine(ulong v)
            => Debt += v;

        private void PayDebt()
        {
            if (!HasDebt)
                return;

            if (!CanSpend(Debt))
            {
                ulong v = (ulong)(Debt - Math.Abs(Balance - (double)Debt));
                Take(v);
                Debt -= v;
                return;
            }

            Take(Debt);
            ClearDebt();
        }

        public void ClearDebt()
            => Debt = 0;


        #endregion
    }
}