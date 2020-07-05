namespace Orikivo
{
    /*
    public class BankCollection
    {
        public List<BankWallet>? Accounts {get; set;}
        public Wallet Wallet {get; set;}
    }
    */

    public enum CurrencyType
    {
        Guild = 0, // guild coins
        User = 1, // user coins
        Voter = 2, // voter tokens
    }
}