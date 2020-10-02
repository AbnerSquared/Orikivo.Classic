using System.Collections.Generic;

namespace Orikivo
{
    /// <summary>
    /// Represents a collection of Orikivo.Report.
    /// </summary>
    public class ReportCollection : IContextCollection<Report>
    {
        public List<Report> Values { get; set; }
    }
}
