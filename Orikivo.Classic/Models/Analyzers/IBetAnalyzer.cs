namespace Orikivo
{
    /// <summary>
    /// Defines the basic properties of a betting analyzer.
    /// </summary>
    public interface IBetAnalyzer
    {
        int PlayCount { get; set; }
        int WinCount { get; set; }
        int LossCount { get; set; }

    }
}
