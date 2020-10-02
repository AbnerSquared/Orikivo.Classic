using System;

namespace Orikivo
{
    public class Fine
    {
        public CurrencyType Currency {get; set;} // the type of currency they have to pay back.
        public DateTime Date {get; set;} // the date this fine was ensued.
        public TimeSpan Duration {get; set;} // the amount of time they have until the fine is a violation.
        public ulong Amount {get; set;} // the funds required to pay off the fine.
    }
}