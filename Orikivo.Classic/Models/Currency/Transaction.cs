namespace Orikivo
{
    public class Transaction
    {
        public Transaction(OldAccount payor, ulong amount)
        {

        }
        public Transaction(OldAccount payor, OldAccount payee, ulong amount)
        {

        }
        // a class for calculating transactions
        public Referent Payor { get; set; } // The person who performed the transaction
        public Referent Payee { get; set; } // The person who received the transaction.
        public ulong Amount { get; set; } // The amount of money that was transferred.
    }
}