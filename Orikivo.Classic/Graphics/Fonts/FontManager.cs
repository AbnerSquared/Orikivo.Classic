using Orikivo.Storage;

namespace Orikivo
{
    public static class FontManager
    {
        public static FontCache FontMap { get; private set; }

        static FontManager()
        {
            FontMap = FileManager.GetFonts();
        }
    }
}