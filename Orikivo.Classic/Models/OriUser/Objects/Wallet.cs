using System.Collections.Generic;

namespace Orikivo.Unstable
{
    public class Wallet
    {
        public CurrencyType Currency {get; set;} // the type of currency.
        public ulong Balance {get; set;} // the balance
        public List<Fine> Fines {get; set;} // the collection of fines appended on a wallet.
        //public ulong Debt {get; set;} // the debt pool
    }
}