namespace Orikivo
{
    // The base class of a card.
    public class Card
    {
        // Card Config
        public int Scale { get; set; } // How big would you want this card to render?
        public CardBorder Border { get; set; }
        public CardBackground Backdrop { get; set; }
    }
}