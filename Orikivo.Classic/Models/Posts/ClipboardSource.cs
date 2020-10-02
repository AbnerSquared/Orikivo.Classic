namespace Orikivo
{
    /// <summary>
    /// Represents the pure content of a Clipboard.
    /// </summary>
    public class ClipboardSource
    {
        public string Message { get; set; } // 2000 char limit
        //public MiniEmbed Embed { get; set; } // 8000 char limit
        public LetterAttachment Attachment { get; set; } // the optional attachment appended to the clipboard.

        // make a quick way to read it...?
    }
}