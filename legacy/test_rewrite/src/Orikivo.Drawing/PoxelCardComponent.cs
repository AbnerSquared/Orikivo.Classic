using System.Drawing;

namespace Orikivo
{
    // a pre-rendered component, ready to be placed onto a PoxelCard.
    public class PoxelCardComponent
    {
        public Point Point { get; }
        public Bitmap Sprite { get; }
    }
}
