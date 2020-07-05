namespace Orikivo
{
    // an interface for a class that contains items, from which is required to be retrieved once starting the bot.
    // as these objects define everything on the bot.
    public interface IDefinerCache
    {
        void Retrieve();
    }
}