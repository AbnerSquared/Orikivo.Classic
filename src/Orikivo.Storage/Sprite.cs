using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Orikivo
{
    /// <summary>
    /// Represents an image resource for Orikivo.
    /// </summary>
    public struct Sprite
    {
        private Sprite(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("The specified path does not contain a value.");
            Source = path;
        }

        public static Sprite FromPath(string path)
            => new Sprite(path);

        public string Source { get; }

        public static implicit operator Bitmap(Sprite spr)
            => new Bitmap(spr);
    }
}
