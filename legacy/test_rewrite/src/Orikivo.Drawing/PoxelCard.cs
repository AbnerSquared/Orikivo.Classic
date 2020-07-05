using System.Collections.Generic;
using System.Drawing;

namespace Orikivo
{
    public class PoxelCard
    {
        public Dictionary<Point, Bitmap> Components { get; private set; }
        public void AddComponent(PoxelCardComponent component)
            => Components.Add(component.Point, component.Sprite);
    }
}
