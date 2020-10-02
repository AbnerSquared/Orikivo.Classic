namespace Orikivo
{
    /// <summary>
    /// Defines a collection of wallet types.
    /// </summary>
    public enum WalletType
    {
        /// <summary>
        /// Defines an offshore wallet as simply storage.
        /// </summary>
        Default = 1,

        /// <summary>
        /// Defines an offshore wallet as built for transactions.
        /// </summary>
        Checkings = 2,

        /// <summary>
        /// Defines an offshore wallet as built for saving money.
        /// </summary>
        Savings = 4
    }
}