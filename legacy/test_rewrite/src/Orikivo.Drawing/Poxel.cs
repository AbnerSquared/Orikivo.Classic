using Discord.WebSocket;
using System;
using System.Drawing;
using System.Text;

namespace Orikivo
{

    public class Poxel : IDisposable
    {
        public Poxel(PoxelRenderingOptions options)
        {
            Font = FontManager.FontMap.GetFont(options.FontId);
            Colors = ColorPacketManager.GetPacket(options.PacketId);
            AlphaColor = options.AlphaColor;
        }

        public void Write(string value) { } // Bitmap => void
        public void Write(Bitmap image, Point point, string value) { } // Bitmap => void
        public void GetAvatar(SocketUser user, PoxelCardAvatarFormat avatarFormat) { } // Bitmap => void
        public PoxelCard GetCard(Account account) { return new PoxelCard(); }
        public byte Scale { get; }
        public FontFace Font { get; }
        public OriColorPacket Colors { get; }
        public OriColor AlphaColor { get; } // can be null
        public void Dispose() { } // clear out all items.
    }
}
