using Newtonsoft.Json;
using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Represents a collection of font sheet data.
    /// </summary>
    public class FontSheetMap
    {
        [JsonConstructor]
        public FontSheetMap(FontSize size, List<FontSheet> sheets)
        {
            Size = size;
            Sheets = sheets;
        }

        [JsonProperty("size")]
        public FontSize Size { get; set; } // the font size for the sheets specified.

        [JsonProperty("sheets")]
        public List<FontSheet> Sheets { get; set; } // the collection of font sheets.
    }
}