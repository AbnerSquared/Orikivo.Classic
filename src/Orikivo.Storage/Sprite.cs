using System;
using System.Drawing;
using System.IO;

namespace Orikivo
{
    /// <summary>
    /// Represents an image resource for Orikivo.
    /// </summary>
    public readonly struct Sprite
    {
        private Sprite(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("The specified path does not contain a value.");
            Source = path;
        }

        public string Source { get; }

        public static implicit operator Bitmap(Sprite sprite)
            => new Bitmap(sprite.Source);
    }
}
